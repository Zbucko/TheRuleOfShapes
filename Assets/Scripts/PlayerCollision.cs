using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ShapeSwitcher shape;
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("UDARIO");
        ObstacleShape obstacle = collision.GetComponent<ObstacleShape>();
        if (obstacle == null)
        {
            Debug.LogWarning("Null je");
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
            FindAnyObjectByType<GameManager>().GameOver();
        }       
    }
}
