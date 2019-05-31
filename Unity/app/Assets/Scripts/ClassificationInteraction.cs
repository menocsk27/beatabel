using System;
using System.IO;
using UnityEngine;

public class ClassificationInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public GameController gameController;
    public GameObject class1;
    public GameObject class2;

    private float distance;
    private bool dragging = false;

    void UpdateClassScales(Vector3 position)
    {
        if (class1)
        {
            float class1Scale = 5 / (Vector2.Distance(position, class1.transform.position) + 0.1F);
            if (class1Scale < 1) class1Scale = 1;
            class1.transform.localScale = new Vector3(class1Scale, class1Scale, 1);
        }
        if (class2)
        {
            float class2Scale = 5 / (Vector2.Distance(position, class2.transform.position) + 0.1F);
            if (class2Scale < 1) class2Scale = 1;
            class2.transform.localScale = new Vector3(class2Scale, class2Scale, 1);
        }
    }

    void ResetClassScales()
    {
        if (class1) class1.transform.localScale = new Vector3(1, 1, 1);
        if (class2) class2.transform.localScale = new Vector3(1, 1, 1);
    }

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

            ResetClassScales();

            // Destroy object
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetClassScales();
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

            UpdateClassScales(position);
        }
    }
}
