using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private PlayerMovement paddle1;
    [SerializeField] private float xPushVelocity = 1f;
    [SerializeField] private float yPushVelocity = 10f;
    [SerializeField] private float randomFactor = 0.01f;
    [SerializeField] private AudioClip[] environmentHitSounds;


    private Vector2 _paddleToBallVector;
    private Rigidbody2D _rb;
    private bool _hasStarted;

    private AudioSource _myAudioSource;

    private void Start()
    {
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.linearVelocity = new Vector2(xPushVelocity, yPushVelocity);
            _hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + _paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(-randomFactor, randomFactor),
                                             Random.Range(-randomFactor, randomFactor));
        if (_hasStarted & other.gameObject.CompareTag("Environment"))
        {
            AudioClip clip = environmentHitSounds[Random.Range(0, environmentHitSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
            _rb.linearVelocity += velocityTweak;
        }
    }
}