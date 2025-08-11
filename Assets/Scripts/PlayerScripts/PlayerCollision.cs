using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ShapeSwitcher shape;
    [SerializeField] AudioManager audioManager;
    [SerializeField] TextMeshProUGUI invincibleTime;
    [SerializeField] float timer;
    public bool isInvincible = false;

    private void OnTriggerEnter(Collider collision)
    {
        ObstacleShape obstacle = collision.GetComponent<ObstacleShape>();
        if (obstacle == null)
        {
            return;
        }
        
        //Check if player is correct shape for the obstacle, and if powerup is active.
        if (obstacle.requiredShape != shape.currentShape && !isInvincible)
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //Check for collision with walls and if powerup is active.
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
}
