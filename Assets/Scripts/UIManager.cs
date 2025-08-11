using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PowerupManager powerupManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI doubleScoreText;
    [SerializeField] TextMeshProUGUI invincibilityText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] Canvas gameOverCanvas;

    public void Start()
    {
        gameOverCanvas.enabled = false;
        doubleScoreText.enabled = false;
        invincibilityText.enabled = false;
    }

    public void Update()
    {
        DisplayScore();
        DisplayDoubleScoreTimer();
        DisplayInvincibilityTimer();
    }

    public void DisplayScore()
    {
        float score = FindAnyObjectByType<ScoreManager>().Score;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void DisplayDoubleScoreTimer()
    {
        float timer = FindAnyObjectByType<PowerupManager>().doubleScoreTimer;
        if (timer <= 0)
        {
            doubleScoreText.enabled = false;
        }
        else
        {
            doubleScoreText.enabled = true;
            doubleScoreText.text = "x2 score: " + Mathf.FloorToInt(timer).ToString();
        }
    }

    public void DisplayInvincibilityTimer()
    {
        float timer = FindAnyObjectByType<PowerupManager>().invincibilityTimer;
        if (timer <= 0)
        {
            invincibilityText.enabled = false;
        }
        else
        {
            invincibilityText.enabled = true;
            invincibilityText.text = "invincibility: " + Mathf.FloorToInt(timer).ToString();
        }
    }

    public void DisplayGameOverScreen()
    {
        invincibilityText.enabled = false;
        doubleScoreText.enabled = false;
        gameOverCanvas.enabled = true;
    }

    public void DisplayNewHighScore()
    {
        highScoreText.enabled = true;
        highScoreText.text = "NEW HIGH SCORE: " + scoreText.text + "\nCongratulations!";
    }

    public void DisplayHighScore()
    {
        highScoreText.enabled = true;
        int highScore = scoreManager.highScore;
        highScoreText.text = "HIGH SCORE: " + highScore;
    }
}
