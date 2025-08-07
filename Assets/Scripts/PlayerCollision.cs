using TMPro;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ShapeSwitcher shape;
    public TextMeshProUGUI tutorialMessage;
    private void OnTriggerEnter(Collider collision)
    {
        ObstacleShape obstacle = collision.GetComponent<ObstacleShape>();
        if (obstacle == null)
        {
            return;
        }

        if (obstacle.requiredShape != shape.currentShape)
        {
            tutorialMessage.text = "Oops, try again!";
            FindAnyObjectByType<GameManager>().GameOver();
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }       
    }
}
