using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderedArea : MonoBehaviour
{
    public MeshFilter meshFilter;
    public Vector2 pixelsLowerLeft;
    public Vector2 pixelsUpperRight;

    public void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

    }
    public void Update()
    {
        CreateAnimationMesh(meshFilter);
    }

    private void CreateAnimationMesh(MeshFilter meshFilter)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(-0.5f,-0.5f);
        vertices[1] = new Vector3(-0.5f,0.5f);
        vertices[2] = new Vector3(0.5f,0.5f);
        vertices[3] = new Vector3(0.5f,-0.5f);

        float textureWidth = 384f;
        float textureHeight = 256f;

        uv[0] = new Vector2(pixelsLowerLeft.x / textureWidth, pixelsLowerLeft.y / textureHeight);
        uv[1] = new Vector2(pixelsLowerLeft.x / textureWidth, pixelsUpperRight.y / textureHeight);
        uv[2] = new Vector2(pixelsUpperRight.x / textureWidth, pixelsUpperRight.y / textureHeight);
        uv[3] = new Vector2(pixelsUpperRight.x / textureWidth, pixelsLowerLeft.y / textureHeight);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        meshFilter.mesh = mesh;


    }
}
