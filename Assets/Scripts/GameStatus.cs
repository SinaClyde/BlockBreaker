using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 2f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 50;
    [SerializeField] private int currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);    
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
        {
            Time.timeScale = gameSpeed;
        }

    public void AddToScore()
        {
            currentScore += pointsPerBlockDestroyed;
            scoreText.text = currentScore.ToString();
        }

    public void ResetGameStatus()
    {
        Destroy(gameObject);
        currentScore = 0;
    }
}