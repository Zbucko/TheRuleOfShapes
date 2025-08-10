using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}
