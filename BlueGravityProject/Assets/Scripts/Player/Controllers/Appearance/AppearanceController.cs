using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceController : MonoBehaviour
{
    [SerializeField] private Texture2D baseTexture;
    [SerializeField] private Texture2D headTexture;
    [SerializeField] private Texture2D bodyTexture;
    [SerializeField] private Material guestMaterial;

    private void Awake()
    {
        Texture2D texture = new Texture2D(384, 256, TextureFormat.RGBA32, true);

        Color[] spriteSheetBasePixels = baseTexture.GetPixels(0,0,384,256);
        texture.SetPixels(0, 0, 384, 256, spriteSheetBasePixels);

        Color[] headPixels = headTexture.GetPixels(0,0,128,128);
        texture.SetPixels(0,128,128,128,headPixels);

        Color[] bodyPixels = bodyTexture.GetPixels(0, 0, 128, 128);
        texture.SetPixels(0, 0, 128, 128, bodyPixels);

        texture.Apply();

        guestMaterial.mainTexture = texture;
    }
}
