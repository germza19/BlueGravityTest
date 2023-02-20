using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderedArea : MonoBehaviour
{
    public MeshFilter meshFilter;


    public bool isFront;
    public Vector2 frontPixelsLowerLeft;
    public Vector2 frontPixelsUpperRight;
    public bool isSide;
    public Vector2 sidePixelsLowerLeft;
    public Vector2 sidePixelsUppderRight;
    public bool isBack;
    public Vector2 backPixelsLowerLeft;
    public Vector2 backPixelsUpperRight;

    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        isFront = true;
        isSide = false;
        isBack = false;
        MovementAnimation();

    }
    public void Update()
    {
        MovementAnimation();
    }
    public void MovementAnimation()
    {
        if (isFront)
        {
            SelectArea(meshFilter, frontPixelsLowerLeft, frontPixelsUpperRight);
        }
        else if (isSide)
        {
            SelectArea(meshFilter, sidePixelsLowerLeft, sidePixelsUppderRight);
        }
        else if (isBack)
        {
            SelectArea(meshFilter, backPixelsLowerLeft, backPixelsUpperRight);
        }
    }

    public void SetIsFront()
    {
        isFront = true;
        isBack = false;
        isSide = false;
    }
    public void SetIsSide()
    {
        isFront = false;
        isBack = false;
        isSide = true;
    }
    public void SetIsBack()
    {
        isFront = false;
        isBack = true;
        isSide = false;
    }

    private void SelectArea(MeshFilter meshFilter, Vector2 currentLowerLeft, Vector2 currentUpperRight)
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

        uv[0] = new Vector2(currentLowerLeft.x / textureWidth, currentLowerLeft.y / textureHeight);
        uv[1] = new Vector2(currentLowerLeft.x / textureWidth, currentUpperRight.y / textureHeight);
        uv[2] = new Vector2(currentUpperRight.x / textureWidth, currentUpperRight.y / textureHeight);
        uv[3] = new Vector2(currentUpperRight.x / textureWidth, currentLowerLeft.y / textureHeight);

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
