using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI references.
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PowerupManager powerupManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI doubleScoreText;
    [SerializeField] TextMeshProUGUI invincibilityText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] Canvas gameOverCanvas;

    private float timer;

    public void Start()
    {
        //Disable canvas and powerup text.
        gameOverCanvas.enabled = false;
        doubleScoreText.enabled = false;
        invincibilityText.enabled = false;
    }

    public void Update()
    {
        //Display score and check for powerup timers.
        DisplayScore();
        DisplayDoubleScoreTimer();
        DisplayInvincibilityTimer();
    }

    public void DisplayScore()
    {
        float score = scoreManager.Score;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void DisplayDoubleScoreTimer()
    {
        //If powerup is active, display durartion.
        timer = powerupManager.doubleScoreTimer;
        if (timer > 0 && timer <=powerupManager.doubleScoreDuration)
        {
            doubleScoreText.enabled = true;
            doubleScoreText.text = "x2 score: " + Mathf.FloorToInt(timer).ToString();
        }
    }

    public void HideDoubleScoreTimer()
    {
        //Hide text when powerup lost.
        powerupManager.doubleScoreTimer = -3f;
        doubleScoreText.enabled = false;
    }

    public void DisplayInvincibilityTimer()
    {
        //If powerup is active, display durartion.
        timer = powerupManager.invincibilityTimer;
        if (timer > 0 && timer <=powerupManager.invincibilityDuration)
        {
            invincibilityText.enabled = true;
            invincibilityText.text = "invincibility: " + Mathf.FloorToInt(timer).ToString();
        }
    }

    public void HideInvincibilityTimer()
    {
        //Hide text when powerup lost.
        invincibilityText.enabled = false;
    }

    public void DisplayGameOverScreen()
    {
        gameOverCanvas.enabled = true;
    }

    public void DisplayNewHighScore()
    {
        //If new highscore is achieved display message.
        highScoreText.enabled = true;
        highScoreText.text = "NEW HIGH SCORE: " + scoreText.text + "\nCongratulations!";
    }

    public void DisplayHighScore()
    {
        //Display the current high score if new high score not achieved.
        highScoreText.enabled = true;
        int highScore = scoreManager.highScore;
        highScoreText.text = "HIGH SCORE: " + highScore;
    }
}
