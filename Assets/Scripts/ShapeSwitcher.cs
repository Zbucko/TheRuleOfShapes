using System;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public enum Shape { Cube, Sphere, Pyramid }
    public Shape currentShape;

    public static event Action<Shape> OnShapeChanged;

    public GameObject shapeHolder;
    public Mesh sphereMesh;
    public Mesh cubeMesh;
    public Mesh pyramidMesh;

    public Color sphereColor = Color.red;
    public Color cubeColor = Color.blue;
    public Color pyramidColor = Color.green;

    public MeshRenderer meshRenderer;
    public SphereCollider sphereCollider;
    public BoxCollider cubeCollider;
    public MeshCollider pyramidCollider;

    void Start()
    {
        //SwitchShape(Shape.Cube);
    }


    // Update is called once per frame
    void Update()
    {
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

    void SwitchShape(Shape newShape)
    {
       // if (currentShape == newShape) return;

        currentShape = newShape;
        var meshFilter = shapeHolder.GetComponent<MeshFilter>();

        sphereCollider.enabled = false;
        cubeCollider.enabled = false;
        pyramidCollider.enabled = false;

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

        //Invokes the event when shape is changed
        OnShapeChanged?.Invoke(newShape); 
    }
}
