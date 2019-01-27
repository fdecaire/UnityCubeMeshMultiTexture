using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    // https://answers.unity.com/questions/312492/submesh-creation-from-script.html
    // https://forum.unity.com/threads/creating-a-mesh-in-c.15454/
    void Start()
    {
        var gameObjects = new List<GameObject>();

        //TODO: break vertices, triangles, uvs into each mesh




        float size = 1f;
        Vector3[] vertices0 =
        {
            // left
            new Vector3(0, 0, size),
            new Vector3(0, size, size),
            new Vector3(0, size, 0),
            new Vector3(0, 0, 0),
        };

        Vector3[] vertices1 =
        {
            // top
            new Vector3(0, size, 0),
            new Vector3(0, size, size),
            new Vector3(size, size, size),
            new Vector3(size, size, 0),
        };

        Vector3[] vertices2 =
        {
            // right
            new Vector3(size, 0, 0),
            new Vector3(size, size, 0),
            new Vector3(size, size, size),
            new Vector3(size, 0, size),
        };

        Vector3[] vertices3 =
        {
            // bottom
            new Vector3(0, 0, size),
            new Vector3(0, 0, 0),
            new Vector3(size, 0, 0),
            new Vector3(size, 0, size),
        };

        Vector3[] vertices4 =
        {
            // back
            new Vector3(size, 0, size),
            new Vector3(size, size, size),
            new Vector3(0, size, size),
            new Vector3(0, 0, size),
        };

        Vector3[] vertices5 =
        {
            // front
            new Vector3(0, 0, 0),
            new Vector3(0, size, 0),
            new Vector3(size, size, 0),
            new Vector3(size, 0, 0),
        };

        // these are all the same for now
        Vector2[] uvs0 =
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };



        AddMeshFilter(gameObjects, "ceil014", vertices0, uvs0);
        AddMeshFilter(gameObjects, "door13_0", vertices1, uvs0);
        AddMeshFilter(gameObjects, "ceil014", vertices2, uvs0);
        AddMeshFilter(gameObjects, "ceil014", vertices3, uvs0);
        AddMeshFilter(gameObjects, "ceil014", vertices4, uvs0);
        AddMeshFilter(gameObjects, "ceil014", vertices5, uvs0);
    }

    private void AddMeshFilter(List<GameObject> o, string textureName, Vector3[] vertices, Vector2[] uvs)
    {
        int[] triangles =
        {
            0, 1, 2, // left
            2, 3, 0,
        };

        o.Add(new GameObject());
        Instantiate(o[o.Count-1]);

        var mesh = new Mesh();
        var meshFilter =
            (UnityEngine.MeshFilter)
            o[o.Count-1].AddComponent(typeof(MeshFilter));
        meshFilter.mesh = mesh;

        // mesh renderer
        var meshRenderer =
            (UnityEngine.MeshRenderer)
            o[o.Count - 1].AddComponent(typeof(MeshRenderer));

        var material = new Material(Shader.Find("Specular"));
        meshRenderer.materials = new Material[1];
        meshRenderer.materials[0] = material;

        //Load a Texture (Assets/Resources/Textures/texture01.png)
        var texture = Resources.Load<Texture2D>($"Textures/{textureName}");
        material.mainTexture = texture;

        meshRenderer.material = material;


        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}
