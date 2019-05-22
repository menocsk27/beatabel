using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    private Texture2D mapTexture;
    private Texture2D clone;
    private Renderer mRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mRenderer = GetComponent<Renderer>();
        mapTexture = Resources.Load<Texture2D>("Images/liverpool") as Texture2D;
        Material material = new Material(Shader.Find("Diffuse"));
        clone = Instantiate(mapTexture);
        material.mainTexture = clone;
        mRenderer.material = material;
        // mRenderer.material.mainTextureScale = new Vector2(-1, -1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnApplicationQuit()
    {
        byte[] bytes = clone.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../ModifiedTexture.png", bytes);
    }

}
