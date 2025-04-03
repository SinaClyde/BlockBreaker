using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip hitBlockSound;
    [SerializeField] private AudioClip breakBlockSound;
    private int _timesHit;
    [SerializeField] private GameObject blockBreakVFX;
    [SerializeField] private Sprite[] hitSprites;
    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _level.CountBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        int hitToDestroy = hitSprites.Length + 1;
        _timesHit++;
        if (_timesHit == hitToDestroy)
        {
            AudioSource.PlayClipAtPoint(breakBlockSound, transform.position, 0.1f);
            TriggerParticleVFX();
            Destroy(gameObject);
            _level.BlockDestroyed();
            FindObjectOfType<GameStatus>().AddToScore();
        }
        else
        {
            AudioSource.PlayClipAtPoint(hitBlockSound, transform.position, 0.1f);
            ShowNextHitSprite();
        }

        Debug.Log(other.gameObject.name);
    }

    void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(blockBreakVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    void ShowNextHitSprite()
    {
        int spriteIndex = _timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }
}