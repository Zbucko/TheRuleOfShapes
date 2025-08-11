using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //Reference to playermovement script.
    [SerializeField] PlayerMovement playerMovement;

    //Changeable intervals for game difficulty.
    [SerializeField] float speedIncreaseInterval = 5f;
    [SerializeField] float speedIncreaseAmount = 0.5f;

    //Reference to UI.
    [SerializeField] UIManager uiManager;
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
        //Checking if speed can be increased every frame.
        IncreaseSpeed();
    }

    private void IncreaseSpeed()
    {
        //If timer is higher than interval, increase speed by increments of 'speedIncreaseAmount'.
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
            //Game over screen appears and checks for highscore.
            playerMovement.enabled = false;
            uiManager.HideDoubleScoreTimer();
            uiManager.DisplayGameOverScreen();
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
        //Function for checking if new highscore is achieved.
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        scoreManager.NewHighScore();
        if (scoreManager.changedScore)
        {
            uiManager.DisplayNewHighScore();
        }
        else
        {
            uiManager.DisplayHighScore();
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
