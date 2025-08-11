using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float Score { get; private set; }
    [SerializeField] PlayerMovement player;
    public float baseMultiplier = 1f;

    public int highScore = 0;
    public bool changedScore = false;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    void Update()
    {
        if (player.enabled)
        {
            float speedFactor = player.forwardSpeed / player.startingSpeed;
            Score += baseMultiplier * speedFactor * Time.deltaTime;
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
}
