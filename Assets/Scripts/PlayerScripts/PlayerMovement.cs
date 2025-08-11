using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Starting speed of player.
    public float startingSpeed = 2;

    //Speed that is increased.
    public float forwardSpeed = 2;

    //Speed of moving left and right.
    public float sidewaysSpeed = 3.5f;

    //Left and right limits, so player doesnt fall off.
    public float leftLimit = -4.0f;
    public float rightLimit = 4.0f;



    // Update is called once per frame
    void FixedUpdate()
    {
        //Constant forward movement.
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);

        //Check for input, then move in that direction.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);
            }
        }
    }
}
