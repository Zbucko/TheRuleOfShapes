using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI doubleScoreText;
    public float Score { get; private set; }
    [SerializeField] PlayerMovement player;
    [SerializeField] float baseMultiplier = 1f;

    public int highScore = 0;
    public bool changedScore = false;

    private float timer;
    private float powerupDuration = 5;

    void Start()
    {
        doubleScoreText.enabled = false;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    void Update()
    {
        if (player.enabled)
        {
            if (timer > 0)
            {
                doubleScoreText.enabled = true;
                doubleScoreText.text = "x2 score: " + Mathf.FloorToInt(timer).ToString();
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    baseMultiplier = 1f;
                    doubleScoreText.enabled = false;
                    FindAnyObjectByType<AudioManager>().PowerLost();
                }
            }
            float speedFactor = player.forwardSpeed / player.startingSpeed;
            Score += baseMultiplier * speedFactor * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(Score).ToString();
        }
    }

    public void NewHighScore()
    {
        if (Score > highScore)
        {
            highScore = Mathf.FloorToInt(Score);
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
            changedScore = true;
        }
    }

    public void ScoreMultiplier()
    {
        baseMultiplier = 2f;
        timer = powerupDuration;
    }
}
