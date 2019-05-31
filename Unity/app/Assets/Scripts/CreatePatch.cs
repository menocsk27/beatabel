using UnityEngine;

public class CreatePatch : MonoBehaviour
{
    public Transform blueprint;
    public float patchDistance = 4;
    public int patchCount = 100;

    private void CreateImagePatch(int i)
    {
        Instantiate(
            blueprint,
            new Vector3(
                blueprint.transform.position.x,
                blueprint.transform.position.y,
                (blueprint.transform.position.z + (i+1) * patchDistance)
            ),
            blueprint.transform.rotation
        );
    }

    void Start()
    {
        for (int i = 0; i < patchCount; i++)
        {
            CreateImagePatch(i);
        }
    }
}
