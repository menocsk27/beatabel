using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "image")
        //Debug.Log("Image collided!");
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("On trigger enter!");

        //Debug.Log(other.gameObject);
    }
}
