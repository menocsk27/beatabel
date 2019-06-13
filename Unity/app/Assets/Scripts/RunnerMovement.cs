using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    public bool autostart = false;
    public float speed = 10.0F;

    private bool running = false;

    void Start()
    {
        if (autostart) running = true;
    }

    public void StartMovement()
    {
        running = true;
    }

    public void StopMovement()
    {
        running = false;
    }

    void Update()
    {
        if (running)
        {
            // Move the object forward along its z axis 1 unit/second.
            transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime), Space.World);
        }
    }
}
