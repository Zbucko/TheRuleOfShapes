using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startingSpeed = 2;
    public float forwardSpeed = 2;
    public float sidewaysSpeed = 3;

    public float leftLimit = -4.0f;
    public float rightLimit = 4.0f;



    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed, Space.World);

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
