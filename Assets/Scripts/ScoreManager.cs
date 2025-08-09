using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float Score { get; private set; }
    [SerializeField] PlayerMovement player;
    [SerializeField] float baseMultiplier = 1f;
    void Update()
    {
        if (player.enabled)
        {
            float speedFactor = player.forwardSpeed / player.startingSpeed;
            Score += baseMultiplier * speedFactor * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(Score).ToString();
        }
    }
}
