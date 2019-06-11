using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class CreateClassifyColliders : MonoBehaviour
{
    public Transform classBlueprint;

    private List<string> classes = new List<string>();

    void Start()
    {
        classes.Add("class1");
        classes.Add("class2");
        classes.Add("class3");
        classes.Add("class4");


        int angleBetween = Mathf.FloorToInt(360 / classes.Count);

        CreateColliders(angleBetween);
    }

    void CreateColliders(int angleBetween)
    {
        float x0 = this.gameObject.transform.position.x;
        float y0 = this.gameObject.transform.position.y;
        float radius = this.gameObject.transform.localScale.x / 2;

        float angle = 0 * Mathf.PI;

       

        for (int i = 0; i < classes.Count; i++)
        {

            Vector3 newLocation = new Vector3(
                   x0 + Mathf.Cos(angle) * radius,
                   y0 + Mathf.Sin(angle) * radius,
                   classBlueprint.transform.position.z
               );


            Debug.Log(classes[i]);
            Debug.Log("angle (rad): " + angle);
            Debug.Log("new loc: " + newLocation + "\n");

            var myClass = Instantiate(
                classBlueprint,
                newLocation,
                classBlueprint.transform.rotation
            );

            myClass.transform.parent = this.gameObject.transform;

            angle = angle + Mathf.Deg2Rad * angleBetween;
        }
    }

    private void Update()
    {
        this.gameObject.transform.Rotate(0f, 0f, 1f);
    }

}