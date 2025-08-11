using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //Follow the player with offset to the back.
        transform.position = player.position + offset;  
    }
}
