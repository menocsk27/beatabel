using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveArea : MonoBehaviour
{
    public Material activeMaterial;
    public string patchTag = "Patch";

    private Material inactiveMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == patchTag)
        {
            GetComponent<MeshRenderer>().material = activeMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == patchTag)
        {
            GetComponent<MeshRenderer>().material = inactiveMaterial;
        }
    }

    void Start()
    {
        inactiveMaterial = GetComponent<MeshRenderer>().material;
    }
}
