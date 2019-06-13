using System;
using System.IO;
using UnityEngine;

public class ClassificationInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public GameController gameController;
    public GameObject interactiveArea;
    public Draggable draggable;

    private void Start()
    {
        draggable = gameObject.GetComponent<Draggable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == interactiveArea)
        {
            draggable.SetDraggable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactiveArea)
        {
            SaveNoClassificationInteraction();

            // Destroy object
            Destroy(gameObject);

            // Update score
            gameController.AddScore(1);
        }
    }

    void SaveNoClassificationInteraction()
    {
        CropImageLoader cropImageLoader = gameObject.GetComponent<CropImageLoader>();
        Vector2Int cropCoordinates = cropImageLoader.GetCropCoordinates();
        Vector2Int cropDimensions = cropImageLoader.GetCropDimensions();
        string imgPath = cropImageLoader.GetImagePath();
        string inputClass = "NONE";
        string input = "1";
        classificationStorage.SaveInteraction(imgPath, inputClass, input, cropCoordinates.x, cropCoordinates.y, cropDimensions.x, cropDimensions.y);
    }
}
