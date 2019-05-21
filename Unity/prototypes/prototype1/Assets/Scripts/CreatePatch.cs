using UnityEngine;

public class CreatePatch : MonoBehaviour
{
    public Transform blueprint;

    private void CreateImagePatch(int i)
    {
        Instantiate(blueprint, new Vector3(0, 0.96F, (20 + i*4)), blueprint.transform.rotation);
    }

    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            CreateImagePatch(i);
        }
    }
}
