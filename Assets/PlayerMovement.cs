using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;

    public float forwardForce = 1000f;
    public float sidewaysForce = 300f;

    // Update is called once per frame
    void FixedUpdate()
    {
        player.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-sidewaysForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(sidewaysForce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
    }
}
