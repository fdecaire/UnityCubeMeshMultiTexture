﻿using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    // https://answers.unity.com/questions/312492/submesh-creation-from-script.html
    // https://forum.unity.com/threads/creating-a-mesh-in-c.15454/
    void Start()
    {
        var gameObjects = new List<GameObject>();

        gameObjects.Add(new GameObject());
        gameObjects.Add(new GameObject());

        Instantiate(gameObjects[0]);
        Instantiate(gameObjects[1]);

        //TODO: create array of meshes
        //TODO: break vertices, triangles, uvs into each mesh
        //TODO: render at the end

        // mesh filter
        var mesh = new Mesh();
        var meshFilter =
            (UnityEngine.MeshFilter)
            gameObjects[0].AddComponent(typeof(MeshFilter));
        meshFilter.mesh = mesh;

        // mesh renderer
        var meshRenderer =
            (UnityEngine.MeshRenderer)
            gameObjects[0].AddComponent(typeof(MeshRenderer));

        var material = new Material(Shader.Find("Specular"));
        meshRenderer.materials = new Material[1];
        meshRenderer.materials[0] = material;
        
        //Load a Texture (Assets/Resources/Textures/texture01.png)
        var texture = Resources.Load<Texture2D>("Textures/ceil014");
        material.mainTexture = texture;
        
        var texture2 = Resources.Load<Texture2D>("Textures/door13_0");

        meshRenderer.material = material;

        float size = 1f;
        Vector3[] vertices = {
            // left
            new Vector3(0, 0, size),
            new Vector3(0, size, size),
            new Vector3(0, size, 0),
            new Vector3(0, 0, 0),

            // top
            new Vector3(0, size, 0),
            new Vector3(0, size, size),
            new Vector3(size, size, size),
            new Vector3(size, size, 0),

            // right
            new Vector3(size, 0, 0),
            new Vector3(size, size, 0),
            new Vector3(size, size, size),
            new Vector3(size, 0, size),

            // bottom
            new Vector3(0, 0, size),
            new Vector3(0, 0, 0),
            new Vector3(size, 0, 0),
            new Vector3(size, 0, size),

            // back
            new Vector3(size, 0, size),
            new Vector3(size, size, size),
            new Vector3(0, size, size),
            new Vector3(0, 0, size),

            // front
            new Vector3(0, 0, 0),
            new Vector3(0, size, 0),
            new Vector3(size, size, 0),
            new Vector3(size, 0, 0),
        };

        int[] triangles = {
            0,1,2, // left
            2,3,0,
            4,5,6, // top
            6,7,4,
            8,9,10, // right
            10,11,8,
            12,13,14, // bottom
            14,15,12,
            16,17,18, // back
            18,19,16,
            20,21,22, // front
            22,23,20
        };


        Vector2[] uvs = {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}