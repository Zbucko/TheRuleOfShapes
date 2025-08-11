using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public float invincibilityTimer = 0f;
    public float doubleScoreTimer = 0f;
    public float invincibilityDuration = 5f;
    public float doubleScoreDuration = 7f;

    void Update()
    {
        CheckInvincibility();
        CheckDoubleScore();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Powerup")
        {
            FindAnyObjectByType<AudioManager>().PowerCollect();
            ActivateDoubleScore();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Invincible")
        {
            FindAnyObjectByType<AudioManager>().PowerCollect();
            ActivateInvincibility();
            Destroy(other.gameObject);
        }
    }

    private void CheckInvincibility()
    {
        invincibilityTimer -= Time.deltaTime;
        if (invincibilityTimer < 0)
        {
            DeactivateInvicibility();
        }
    }

    private void CheckDoubleScore()
    {
        doubleScoreTimer -= Time.deltaTime;
        if (doubleScoreTimer < 0)
        {
            DeactivateDoubleScore();
        }
    }

    void ActivateInvincibility()
    {
        FindAnyObjectByType<PlayerCollision>().isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }

    private void ActivateDoubleScore()
    {
        FindAnyObjectByType<ScoreManager>().baseMultiplier = 2f;
        doubleScoreTimer = doubleScoreDuration;
    }

    private void DeactivateDoubleScore()
    {
        FindAnyObjectByType<ScoreManager>().baseMultiplier = 1f;
        doubleScoreTimer = 0f;
    }

    void DeactivateInvicibility()
    {
        FindAnyObjectByType<PlayerCollision>().isInvincible = false;
        invincibilityTimer = 0f;
    }
}
