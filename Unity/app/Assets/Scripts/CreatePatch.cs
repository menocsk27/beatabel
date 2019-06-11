using System.Collections;
using UnityEngine;

public class CreatePatch : MonoBehaviour
{
    public Transform blueprint;
    public float patchDistance = 10;

    public ImageLoader imageLoader;
    public int cropWidth = 100;
    public int cropHeight = 100;

    // Number of beats to use for determining the beats per minute
    public int beatAccuracy = 2;

    private AudioProcessor audioProcessor;
    private Queue beats = new Queue();
    private float bpm; // beats per minute
    private System.Diagnostics.Stopwatch beatStopwatch = new System.Diagnostics.Stopwatch();

    private void CreateImagePatch(float zPosition, int cropX, int cropY)
    {
        Transform clone = Instantiate(
            blueprint,
            new Vector3(
                blueprint.transform.position.x,
                blueprint.transform.position.y,
                zPosition
             ),
            blueprint.transform.rotation
        );
        
        clone.GetComponent<CropImageLoader>().SetCropCoordinates(cropX * cropWidth, cropY * cropHeight);
        clone.GetComponent<CropImageLoader>().SetCropDimensions(cropWidth, cropHeight);
    }

    private void CreateImagePatches()
    {
        Vector2 imgDim = imageLoader.GetDimensions();

        int xCount = Mathf.FloorToInt(imgDim.x / cropWidth);
        int yCount = Mathf.FloorToInt(imgDim.y / cropHeight);

        int i = 1;
        for (int x = 0; x < xCount; x++)
        {
            for (int y = 0; y < yCount; y++)
            {
                float zPosition = blueprint.transform.position.z + i * patchDistance;
                CreateImagePatch(zPosition, x, y);
                i++;
            }
        }
    }

    private void OnBeat()
    {
        // Start tracking the beats
        if (beats.Count == 0)
        {
            beatStopwatch.Start();
        }

        // Track beat
        beats.Enqueue(beatStopwatch.Elapsed);

        // Evaluate beats
        if (beats.Count >= beatAccuracy)
        {
            beatStopwatch.Stop();
            audioProcessor.onBeat.RemoveListener(OnBeat);
            Debug.Log(beats);

            // TODO: Process beats and start game
            CreateImagePatches();
        }
    }

    void Start()
    {
        audioProcessor = FindObjectOfType<AudioProcessor>();
        audioProcessor.onBeat.AddListener(OnBeat);
    }
}
