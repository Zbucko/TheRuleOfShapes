using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Deleting the object when passed through.
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
