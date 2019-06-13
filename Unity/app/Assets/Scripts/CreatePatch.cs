using System.Collections.Generic;
using UnityEngine;

public class CreatePatch : MonoBehaviour
{
    public Transform blueprint;
    public Transform interactiveArea;
    public float patchDistance = 10;

    public ImageLoader imageLoader;
    public int cropWidth = 100;
    public int cropHeight = 100;

    // Number of intervals between beats to use for determining the beats per minute
    public int beatAccuracy = 3;

    private AudioProcessor audioProcessor;
    private Stack<long> beats;
    private float beatInterval; // milliseconds between beats
    private float patchSpeed;

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

        CropImageLoader cropImageLoader = clone.GetComponent<CropImageLoader>();
        cropImageLoader.SetCropCoordinates(cropX * cropWidth, cropY * cropHeight);
        cropImageLoader.SetCropDimensions(cropWidth, cropHeight);

        RunnerMovement runnerMovement = clone.GetComponent<RunnerMovement>();
        runnerMovement.StartMovement();
        runnerMovement.speed = patchSpeed;
    }

    private void CreateImagePatches()
    {
        float distance = Vector2.Distance(blueprint.position, interactiveArea.position);
        patchSpeed = distance / (2 * beatInterval / 1000);
        float zDelta = patchSpeed * (2 * beatInterval / 1000);
        Debug.Log(patchSpeed);
        Debug.Log(zDelta);

        Vector2 imgDim = imageLoader.GetDimensions();

        int xCount = Mathf.FloorToInt(imgDim.x / cropWidth);
        int yCount = Mathf.FloorToInt(imgDim.y / cropHeight);

        int i = 1;
        for (int x = 0; x < xCount; x++)
        {
            for (int y = 0; y < yCount; y++)
            {
                float zPosition = blueprint.transform.position.z + i * zDelta;
                CreateImagePatch(zPosition, x, y);
                i++;
            }
        }
    }

    private void OnBeat()
    {
        if (beats.Count < beatAccuracy + 1)
        {
            // Track beat
            long milliseconds = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            beats.Push(milliseconds);
        } else
        {
            audioProcessor.onBeat.RemoveListener(OnBeat);

            // Average over all beat intervals
            beatInterval = 0;
            while (beats.Count > 1)
            {
                long first = beats.Pop();
                long second = beats.Peek();
                beatInterval += first - second;
            }
            beatInterval /= beatAccuracy + 1;
            
            // Start game
            CreateImagePatches();
        }
    }

    void Start()
    {
        beats = new Stack<long>();
        audioProcessor = FindObjectOfType<AudioProcessor>();
        audioProcessor.onBeat.AddListener(OnBeat);
    }
}
