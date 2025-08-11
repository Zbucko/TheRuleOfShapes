using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PlayerCollision player;
    [SerializeField] ScoreManager score;
    [SerializeField] UIManager uimanager;
    [SerializeField] AudioManager audioManager;
    public float invincibilityTimer = -3f;
    public float doubleScoreTimer = -3f;
    public float invincibilityDuration = 5f;
    public float doubleScoreDuration = 7f;

    void Update()
    {
        //Checking timers.
        CheckInvincibility();
        CheckDoubleScore();
    }
    void OnTriggerEnter(Collider other)
    {
        //Checking which powerup is collected.
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
        //If timer is between 0 and -1, deactivate power.
        invincibilityTimer -= Time.deltaTime;
        if (invincibilityTimer <= 0 && invincibilityTimer > -1)
        {
            DeactivateInvicibility();
        }
    }

    private void CheckDoubleScore()
    {
        //If timer is between 0 and -1, deactivate power.
        doubleScoreTimer -= Time.deltaTime;
        if (doubleScoreTimer <= 0 && doubleScoreTimer > -2)
        {
            DeactivateDoubleScore();
        }
    }

    void ActivateInvincibility()
    {
        //Activate power.
        player.isInvincible = true;
        invincibilityTimer = invincibilityDuration;
    }
    void DeactivateInvicibility()
    {
        //Deactivate power by reseting the timer.
        player.isInvincible = false;
        audioManager.PowerLost();
        uimanager.HideInvincibilityTimer();
        invincibilityTimer = -3f;
    }

    private void ActivateDoubleScore()
    {
        //Activate power.
        score.baseMultiplier = 2f;
        doubleScoreTimer = doubleScoreDuration;
    }

    public void DeactivateDoubleScore()
    {
        //Deactivate power by reseting timer.
        score.baseMultiplier = 1f;
        audioManager.PowerLost();
        uimanager.HideDoubleScoreTimer();
        doubleScoreTimer = -3f;
    }

    
}
