using UnityEngine;
using System.Collections;

public class DraggableRaycast : MonoBehaviour
{
    private Vector3 screenPos;
    private Vector3 offset;
    private bool isMouseDrag = false;

    GameObject target = null;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction * 100, out hit))
            {
                target = hit.collider.gameObject;
            }

            if (target != null)
            {
                if (hit.transform.tag.StartsWith("Patch"))
                {
                    isMouseDrag = true;

                    // world pos to screen pos
                    screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
                    Vector3 newPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint(newPos);
                } 
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDrag = false;
        }

        if (isMouseDrag)
        {
            // track mouse pos
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);

            // screen pos to world pos + offset
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

            target.transform.position = currentPos;
        }






    }
}