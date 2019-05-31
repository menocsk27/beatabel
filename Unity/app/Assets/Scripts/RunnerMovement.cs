using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    public float speed = 10.0F;

    void Update()
    {
        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime), Space.World);
    }
}
