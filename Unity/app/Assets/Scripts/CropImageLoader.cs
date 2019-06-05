using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CropImageLoader : MonoBehaviour
{
    public ImageLoader imageLoader;
   
    private Renderer mRenderer;
    private Texture2D modified;

    private int xCropPos = 0;
    private int yCropPos = 0;
    private int cropWidth = 100;
    private int cropHeight = 100;

    void Start()
    {
        mRenderer = GetComponent<Renderer>();
        
        // get crop from original image
        Texture2D cropped = imageLoader.GetComponent<ImageLoader>().GetCroppedTexture(xCropPos, yCropPos, cropWidth, cropHeight);

        // set texture
        Material material = new Material(Shader.Find("Diffuse"));
        material.mainTexture = cropped;
        mRenderer.material = material;
        // mRenderer.material.mainTextureScale = new Vector2(-1, -1);    
    }

    public void SetCropCoordinates(int x, int y)
    {
        this.xCropPos = x;
        this.yCropPos = y;
    }

    public void SetCropDimensions(int cropWidth, int cropHeight)
    {
        this.cropWidth = cropWidth;
        this.cropHeight = cropHeight;
    }


    private void OnApplicationQuit()
    {
        //byte[] bytes = modified.EncodeToPNG();
        //File.WriteAllBytes(Application.dataPath + "/../ModifiedTexture.png", bytes);
    }
}
