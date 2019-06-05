using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    private Texture2D mapTexture;
    private Texture2D clone;

    // Start is called before the first frame update
    void Start()
    {
        // get original texture / image and copy it
        mapTexture = Resources.Load<Texture2D>("Images/liverpool") as Texture2D;
        clone = Instantiate(mapTexture);
    }

    public Texture2D GetCroppedTexture(int x, int y, int cropWidth, int cropHeight)
    {
        Color[] pixels = clone.GetPixels(x, y, cropWidth, cropHeight, 0);

        //print("Pos: x: " + x + " y: " + y + " Width: " + cropWidth + " Height: " + cropHeight);
        Texture2D cropped = new Texture2D(cropWidth, cropHeight, TextureFormat.ARGB32, false);
        cropped.SetPixels(0, 0, cropped.width, cropped.height, pixels, 0);
        cropped.Apply();

        return cropped;
    }

    public Vector2 GetDimensions()
    {
        return new Vector2(clone.width, clone.height);
    }
}
