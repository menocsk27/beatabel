using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
    }

    void Update()
    {
        this.gameObject.transform.Rotate(0f, 0f, rotationSpeed);
    }
}
