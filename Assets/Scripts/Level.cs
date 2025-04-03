using UnityEngine;


public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks;
    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            _levelManager.LoadNextScene();
        }
    }
}