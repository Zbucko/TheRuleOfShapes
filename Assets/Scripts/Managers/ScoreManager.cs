using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float Score { get; private set; }
    [SerializeField] PlayerMovement player;
    [SerializeField] UIManager uiManager;
    public float baseMultiplier = 1f;

    public int highScore = 0;
    public bool changedScore = false;

    void Start()
    {
        //Check for current highscore, if there is none, set to 0.
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    void Update()
    {
        if (player.enabled)
        {
            //Constant score increment used with speed factor, to scale with player speed.
            float speedFactor = player.forwardSpeed / player.startingSpeed;
            Score += baseMultiplier * speedFactor * Time.deltaTime;
        }
    }

    public void NewHighScore()
    {
        //If new highscore is achieved, write it to playerprefs and change bool to true.
        if (Score > highScore)
        {
            highScore = Mathf.FloorToInt(Score);
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
            changedScore = true;
        }
    }
}
