using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public GameObject floor;
    private Vector3 floorSpawnPosition;
    private float floorShift;

    // Start is called before the first frame update
    void Start()
    {
        floorSpawnPosition = floor.transform.position;
        floorShift = floor.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        // player
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

        // spawn floor
        if (Input.GetKey(KeyCode.Space))
        {
            floorSpawnPosition.z += floorShift;
            Instantiate(floor, floorSpawnPosition, floor.transform.rotation);

        }
    }
}
