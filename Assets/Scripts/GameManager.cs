using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float speedIncreaseInterval = 5f;
    [SerializeField] float speedIncreaseAmount = 0.5f;
    [SerializeField] TextMeshProUGUI highScoreText;

    public Canvas gameOverScreen;
    public float restartDelay = 1.25f;
    private float timer = 0;

    void Start()
    {
        FindAnyObjectByType<ShapeSwitcher>().SwitchShape(ShapeSwitcher.Shape.Cube);
        gameOverScreen.enabled = false;
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= speedIncreaseInterval)
        {
            playerMovement.forwardSpeed += speedIncreaseAmount;
            timer = 0f;
        }
    }
    public void GameOver()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            TutorialGameOver();
        }
        else
        {
            playerMovement.enabled = false;
            gameOverScreen.enabled = true;
            FindAnyObjectByType<ScoreManager>().doubleScoreText.enabled = false;
            FindAnyObjectByType<SegmentGenerationManager>().enabled = false;
            CheckHighScore();
            FindAnyObjectByType<AudioManager>().GameOverMusic();
        }
        

    }

    public void TutorialGameOver()
    {
        playerMovement.enabled = false;
        gameOverScreen.enabled = true;
        FindAnyObjectByType<AudioManager>().GameOverMusic();
    }

    void CheckHighScore()
    {
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        scoreManager.NewHighScore();
        if (scoreManager.changedScore)
        {
            highScoreText.text = "NEW HIGH SCORE: " + scoreManager.scoreText.text+"\nCongratulations!";
        }
        else
        {
            highScoreText.text = "HIGH SCORE: " + scoreManager.highScore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
