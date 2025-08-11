using System;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    //Shapes that are used.
    public enum Shape { Cube, Sphere, Pyramid }

    //Current shape of the player.
    public Shape currentShape;

    //Event for changing shapes.
    public static event Action<Shape> OnShapeChanged;

    [SerializeField] GameObject shapeHolder;
    [SerializeField] Mesh sphereMesh;
    [SerializeField] Mesh cubeMesh;
    [SerializeField] Mesh pyramidMesh;

    public Color sphereColor = Color.red;
    public Color cubeColor = Color.blue;
    public Color pyramidColor = Color.green;

    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] BoxCollider cubeCollider;
    [SerializeField] MeshCollider pyramidCollider;

    [SerializeField] AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        //Check for input, then change shape.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchShape(Shape.Cube);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchShape(Shape.Sphere);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchShape(Shape.Pyramid);
        }
    }

    public void SwitchShape(Shape newShape)
    {
        currentShape = newShape;
        var meshFilter = shapeHolder.GetComponent<MeshFilter>();

        //Turn off all colliders before changing to new shape.
        sphereCollider.enabled = false;
        cubeCollider.enabled = false;
        pyramidCollider.enabled = false;

        //Based on input, change mesh, collider and color to match shape.
        switch (newShape)
        {
            case Shape.Cube:
                meshFilter.mesh = cubeMesh;
                meshRenderer.material.color = cubeColor;
                cubeCollider.enabled = true;
                break;

            case Shape.Sphere:
                meshFilter.mesh = sphereMesh;
                meshRenderer.material.color = sphereColor;
                sphereCollider.enabled = true;
                break;

            case Shape.Pyramid:
                meshFilter.mesh = pyramidMesh;
                meshRenderer.material.color = pyramidColor;
                pyramidCollider.sharedMesh = pyramidMesh;
                pyramidCollider.convex = true;
                pyramidCollider.enabled = true;
                break;

        }
        audioManager.PlayShapeChange();

        //Invokes the event when shape is changed
        OnShapeChanged?.Invoke(newShape); 
    }
}
