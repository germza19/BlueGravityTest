using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceController : MonoBehaviour
{
    [SerializeField] private Texture2D baseTexture;

    [SerializeField] private Texture2D headTextureFront;
    [SerializeField] private Texture2D bodyTextureFront;

    [SerializeField] private Texture2D headTextureSide;
    [SerializeField] private Texture2D bodyTextureSide;

    [SerializeField] private Texture2D headTextureBack;
    [SerializeField] private Texture2D bodyTextureBack;

    [SerializeField] private Material guestMaterial;

    public int headIndex;
    public int bodyIndex;

    private void Update()
    {
        ChangeSprites(headIndex, bodyIndex);
    }

    public void ChangeSprites(int headIndex,int bodyIndex)
    {
        Texture2D texture = new Texture2D(384, 256, TextureFormat.RGBA32, true);

        //Front
        Color[] spriteSheetBasePixelsFront = baseTexture.GetPixels(0, 0, 384, 256);
        texture.SetPixels(0, 0, 384, 256, spriteSheetBasePixelsFront);

        Color[] headPixels = headTextureFront.GetPixels(128 * headIndex, 0, 128, 128);
        texture.SetPixels(0, 128, 128, 128, headPixels);

        Color[] bodyPixels = bodyTextureFront.GetPixels(128 * bodyIndex, 0, 128, 128);
        texture.SetPixels(0, 0, 128, 128, bodyPixels);

        //Side
        //Color[] spriteSheetBasePixelsSide = baseTexture.GetPixels(0, 0, 384, 256);
        //texture.SetPixels(0, 0, 384, 256, spriteSheetBasePixelsSide);

        Color[] headPixelsSide = headTextureSide.GetPixels(128 * headIndex, 0, 128, 128);
        texture.SetPixels(128, 128, 128, 128, headPixelsSide);

        Color[] bodyPixelsSide = bodyTextureSide.GetPixels(128 * bodyIndex, 0, 128, 128);
        texture.SetPixels(128, 0, 128, 128, bodyPixelsSide);

        //Back
        //Color[] spriteSheetBasePixelsBack = baseTexture.GetPixels(0, 0, 384, 256);
        //texture.SetPixels(0, 0, 384, 256, spriteSheetBasePixelsBack);

        Color[] headPixelsSideBack = headTextureBack.GetPixels(128 * headIndex, 0, 128, 128);
        texture.SetPixels(256, 128, 128, 128, headPixelsSideBack);

        Color[] bodyPixelsSideBack = bodyTextureBack.GetPixels(128 * bodyIndex, 0, 128, 128);
        texture.SetPixels(256, 0, 128, 128, bodyPixelsSideBack);

        texture.Apply();

        guestMaterial.mainTexture = texture;
    }
}
