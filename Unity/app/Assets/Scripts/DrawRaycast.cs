using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRaycast : MonoBehaviour
{
    public Camera cam;
    public int brushWidth = 25;
    public int brushHeight = 25;
    public Color color = Color.white;

    private Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        colors = new Color[brushWidth * brushHeight];
        for (int i = 0; i < brushWidth * brushHeight; i++)
        {
            colors[i] = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
        {
            return;
        }

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;

        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixels((int)pixelUV.x, (int)pixelUV.y, brushWidth, brushHeight, colors);
        tex.Apply();
    }
}
