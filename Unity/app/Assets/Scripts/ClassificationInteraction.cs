﻿using System;
using System.IO;
using UnityEngine;

public class ClassificationInteraction : MonoBehaviour
{
    public ClassificationStorage classificationStorage;
    public GameController gameController;
    public GameObject interactiveArea;

    // TODO: Remove?
    public GameObject class1;

    // TODO: Remove?
    public GameObject class2;

    private bool allowDragging = false;
    private bool dragging = false;

    // TODO: Remove?
    private float distance;

    // TODO: Remove?
    private Vector2 centerPosition = new Vector2(0, 0);

    // TODO: Remove?
    void UpdateClassScale(GameObject cls, Vector2 position)
    {
        Vector2 classPosition = new Vector2(cls.transform.position.x, cls.transform.position.y);
        Vector2 centerToCls = centerPosition - classPosition;
        Vector2 positionToCls = classPosition - position;
        float angle = Vector2.SignedAngle(centerToCls, positionToCls);
        
        float classScale = (Math.Abs(angle) < 10) ? Vector2.Distance(centerPosition, position) : 1;
        cls.transform.localScale = new Vector3(classScale, classScale, cls.transform.localScale.z);
    }

    // TODO: Remove?
    void UpdateClassScales(Vector2 position)
    {
        if (class1) UpdateClassScale(class1, position);
        if (class2) UpdateClassScale(class2, position);
    }

    // TODO: Remove?
    void ResetClassScales()
    {
        if (class1) class1.transform.localScale = new Vector3(1, 1, 1);
        if (class2) class2.transform.localScale = new Vector3(1, 1, 1);
    }

    void SaveInteraction(string input)
    {
        CropImageLoader cropImageLoader = gameObject.GetComponent<CropImageLoader>();
        Vector2Int cropCoordinates = cropImageLoader.GetCropCoordinates();
        Vector2Int cropDimensions = cropImageLoader.GetCropDimensions();
        string imgPath = cropImageLoader.GetImagePath();
        string inputClass = "city";
        classificationStorage.SaveInteraction(imgPath, inputClass, input, cropCoordinates.x, cropCoordinates.y, cropDimensions.x, cropDimensions.y);

        ResetClassScales();

        // Destroy object
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        if (allowDragging)
        {
            dragging = true;

            Vector3 position = gameObject.transform.position;
            centerPosition = new Vector2(position.x, position.y);
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
            string input = (gameObject.transform.position.x > 0) ? "1" : "0";
            SaveInteraction(input);
        }
    }

    void Start()
    {
        ResetClassScales();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == interactiveArea)
        {
            allowDragging = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactiveArea)
        {
            SaveInteraction("NULL");
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

            UpdateClassScales(new Vector2(position.x, position.y));
        }
    }
}
