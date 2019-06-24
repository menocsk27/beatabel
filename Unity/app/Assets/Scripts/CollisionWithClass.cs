using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithClass : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public GameObject interactiveArea;

    Color originalColor;
    // value to fade down to
    [Range(0f, 1f)]
    public float fadeToAmount = 0f;
    // fading speed
    public float fadingSpeed = 0.05f;

    void Start()
    {
        classificationStorage = GameObject.Find("GameController").GetComponent<ClassificationStorage>();
        originalColor = this.gameObject.GetComponent<Renderer>().material.color;

        interactiveArea = GameObject.Find("InteractiveArea");
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Image collided!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.StartsWith("Patch"))
        {
            SaveInteraction(other.gameObject);
            StartCoroutine("FadeToColor");

            // set platform color
            interactiveArea.GetComponent<InteractiveArea>().ResetColor();
        }
       
    }

    IEnumerator FadeToColor()
    {
        Renderer rend = this.gameObject.GetComponent<Renderer>();
        rend.material.color = originalColor;

        for (float i = 1f; i >= fadeToAmount; i -= 0.15f)
        {
            Color c = originalColor - new Color(i, i, i);
            rend.material.color = c;

            yield return new WaitForSeconds(fadingSpeed);
        }
    }

    void SaveInteraction(GameObject go)
    {
        Debug.Log(go.name);
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
