using UnityEngine;
using UnityEditor;

public class PyramidMeshCreator
{
    [MenuItem("Tools/Create Pyramid Mesh Asset")]
    public static void CreatePyramidMesh()
    {
        Mesh pyramidMesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 1, 0),         // top
            new Vector3(-0.5f, 0, 0.5f),  // front-left
            new Vector3(0.5f, 0, 0.5f),   // front-right
            new Vector3(0.5f, 0, -0.5f),  // back-right
            new Vector3(-0.5f, 0, -0.5f)  // back-left
        };

        int[] triangles = new int[]
        {
            0, 1, 2, // front
            0, 2, 3, // right
            0, 3, 4, // back
            0, 4, 1, // left
            1, 4, 3, // bottom 1
            1, 3, 2  // bottom 2
        };

        pyramidMesh.vertices = vertices;
        pyramidMesh.triangles = triangles;
        pyramidMesh.RecalculateNormals();

        AssetDatabase.CreateAsset(pyramidMesh, "Assets/pyramidMesh.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("Pyramid mesh created at Assets/pyramidMesh.asset");
    }
}