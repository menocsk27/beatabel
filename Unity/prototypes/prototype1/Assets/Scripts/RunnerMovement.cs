using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(new Vector3(0, 0, -4 * Time.deltaTime), Space.World);
    }
}
