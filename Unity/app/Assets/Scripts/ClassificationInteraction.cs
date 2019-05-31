using System;
using System.IO;
using UnityEngine;

public class ClassificationInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public GameController gameController;

    private float distance;
    private bool dragging = false;

    void OnMouseDown()
    {
        if (gameObject.transform.position.z <= 0.0)
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            dragging = true;
        }
    }

    void OnMouseUp()
    {
        if (dragging)
        {
            // Stop dragging
            dragging = false;

            // Update score
            gameController.AddScore(1);

            // Add to stored interactions
            float input = (gameObject.transform.position.x > 0) ? 1 : 0;
            classificationStorage.SaveInteraction(input);

            // Destroy object
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (dragging)
        {
            // Allow dragging along x-y-plain
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            Vector3 prevPosition = gameObject.transform.position;
            Vector3 position = new Vector3(rayPoint.x, rayPoint.y, prevPosition.z);
            transform.position = position;
        }
    }
}
