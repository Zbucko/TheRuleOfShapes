using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ShapeSwitcher shape;
    public TutorialManager tutorialManager;
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
            FindAnyObjectByType<GameManager>().GameOver();
        }
        else if (collision.collider.tag == "Finish")
        {
            //Display end of tutorial message.
            tutorialManager.EndOfTutorial();
        }     
    }
}
