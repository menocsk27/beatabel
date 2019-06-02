using UnityEngine;

public class CreatePatch : MonoBehaviour
{
    public Transform blueprint;
    public float patchDistance = 10;

    public ImageLoader imageLoader;
    public int cropWidth = 100;
    public int cropHeight = 100;

    private int patchCount; // implicit

    void Start()
    {
        CreateImagePatch();
    }

    private void CreateImagePatch()
    {
        Vector2 imgDim = imageLoader.GetDimensions();

        // img area divided by crop area
        patchCount = Mathf.FloorToInt(imgDim.x * imgDim.y / (cropWidth * cropHeight));

        int xCount = Mathf.FloorToInt(imgDim.x / cropWidth);
        int yCount = Mathf.FloorToInt(imgDim.y / cropHeight);

        int i = 0;
        for (int x = 0; x < xCount; x++)
        {
            for (int y = 0; y < yCount; y++)
            {
                Transform clone;
                clone = Instantiate(
                    blueprint,
                    new Vector3(
                        blueprint.transform.position.x,
                        blueprint.transform.position.y,
                        (blueprint.transform.position.z + (i + 1) * patchDistance)
                    ),
                    blueprint.transform.rotation
                );
                i++;

                clone.GetComponent<CropImageLoader>().SetCropCoordinates(x * cropWidth, y * cropHeight);
                clone.GetComponent<CropImageLoader>().SetCropDimensions(cropWidth, cropHeight);
            }
        }
    }
}
