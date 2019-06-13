using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;

    void Start()
    {
        classificationStorage = GameObject.Find("GameController").GetComponent<ClassificationStorage>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Image collided!");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("On trigger enter!");
        SaveInteraction(other.gameObject);
    }

    void SaveInteraction(GameObject go)
    {
        CropImageLoader cropImageLoader = go.GetComponent<CropImageLoader>();
        Vector2Int cropCoordinates = cropImageLoader.GetCropCoordinates();
        Vector2Int cropDimensions = cropImageLoader.GetCropDimensions();
        string imgPath = cropImageLoader.GetImagePath();

        string inputClass = this.gameObject.name; // the class from the collider
        string input = "1"; // == TRUE -> actually not needed (TODO)
        classificationStorage.SaveInteraction(imgPath, inputClass, input, cropCoordinates.x, cropCoordinates.y, cropDimensions.x, cropDimensions.y);

        // Destroy crop object
        Destroy(go);
    }
}
