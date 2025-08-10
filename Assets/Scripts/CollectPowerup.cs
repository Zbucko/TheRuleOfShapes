using UnityEngine;

public class CollectPowerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Powerup")
        {
            FindAnyObjectByType<AudioManager>().PowerCollect();
            FindAnyObjectByType<ScoreManager>().ScoreMultiplier();
            Destroy(other.gameObject);
        }
    }
}
