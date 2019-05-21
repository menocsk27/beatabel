using System;
using System.IO;
using UnityEngine;

public class ClassificationStorage : MonoBehaviour
{
    private string filePath= "data/users.csv";

    public void SaveInteraction(float input)
    {
        // Create directory if it does not exist
        FileInfo fileInfo = new FileInfo(filePath);
        string directory = fileInfo.Directory.Name;
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Append line to file
        StreamWriter writer = new StreamWriter(filePath, true);
        string imageId = "imageId";
        int xPos = 0;
        int yPos = 0;
        int width = 512;
        int height = 512;
        string cls = "city";
        string classification = imageId + "," + xPos + "," + yPos + "," + width + "," + height + "," + cls + "," + input;
        writer.WriteLine(classification);
        writer.Close();
    }
}
