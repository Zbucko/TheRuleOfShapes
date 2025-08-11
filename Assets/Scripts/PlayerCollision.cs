using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ShapeSwitcher shape;
    [SerializeField] AudioManager audioManager;
    [SerializeField] TextMeshProUGUI invincibleTime;
    [SerializeField] float timer;
    public bool isInvincible = false;

    void Update()
    {
        //CheckInvincibility();
    }
    private void OnTriggerEnter(Collider collision)
    {
        ObstacleShape obstacle = collision.GetComponent<ObstacleShape>();
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.requiredShape != shape.currentShape && !isInvincible)
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && !isInvincible)
        {
            //Restart the level.
            audioManager.PlayCollision();
            FindAnyObjectByType<GameManager>().GameOver();
        }
        else if (collision.collider.tag == "Finish")
        {
            //Display end of tutorial message.
            FindAnyObjectByType<TutorialManager>().EndOfTutorial();
        }
    }

    public void ActivateInvincibility(float duration)
    {
        isInvincible = true;
        timer = duration;
    }

    private void CheckInvincibility()
    {
        if (isInvincible)
        {
            invincibleTime.enabled = true;
            invincibleTime.text ="Invincible: " + Mathf.FloorToInt(timer).ToString();
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isInvincible = false;
                invincibleTime.enabled = false;
            }
        }
    }
}
