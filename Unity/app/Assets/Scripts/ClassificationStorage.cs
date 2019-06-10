using System;
using System.IO;
using UnityEngine;

public class ClassificationStorage : MonoBehaviour
{
    private string filePath= "data/users.csv";

    public void SaveInteraction(string imgPath, string inputClass, string input, int xPos, int yPos, int cropWidth, int cropHeight)
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
        string classification = imgPath + "," + xPos + "," + yPos + "," + cropWidth + "," + cropHeight + "," + inputClass + ',' + input;
        writer.WriteLine(classification);
        writer.Close();
    }
}
