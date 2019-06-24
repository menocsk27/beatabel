using UnityEngine;

public class ClassificationInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public Score score;
    public GameObject interactiveArea;

    private Draggable draggable;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        draggable = gameObject.GetComponent<Draggable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "InteractiveArea")
        {
            draggable.SetDraggable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "InteractiveArea")
        {
            SaveNoClassificationInteraction();

            // Destroy object
            Destroy(gameObject);

            // Update score
            // TODO: Score: Determine accuracy according to the interaction timing
            float accuracy = Random.Range(-1.0F, 1.0F);
            score.AddScore(accuracy);
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
