using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ShapeSwitcher shape;
    [SerializeField] AudioManager audioManager;
    private void OnTriggerEnter(Collider collision)
    {
        ObstacleShape obstacle = collision.GetComponent<ObstacleShape>();
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.requiredShape != shape.currentShape)
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
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
