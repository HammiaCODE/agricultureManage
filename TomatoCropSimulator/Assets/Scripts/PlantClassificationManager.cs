using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlantClassificationManager : MonoBehaviour
{

    private int count = 0;

    private async void Start()
    {
        string basePath = Application.dataPath;

        string healthyDir = Path.Combine(basePath, "Scripts", "Images", "Healthy fruit", "T_F_H - Copy");
        string rugoseDir  = Path.Combine(basePath, "Scripts", "Images", "Rugose Fruit", "T_F_R - Copy");

        Debug.Log("Healthy dir: " + healthyDir);
        Debug.Log("Rugose dir: "  + rugoseDir);

        List<string> allImages = new List<string>();
        AddImagesFromFolder(healthyDir, allImages);
        AddImagesFromFolder(rugoseDir, allImages);

        if (allImages.Count == 0)
        {
            Debug.LogError("No images found in the specified folders!");
            return;
        }
        
   
        PlantHolder[] plants = FindObjectsByType<PlantHolder>(FindObjectsSortMode.None);
        
        foreach (var plant in plants)
        {
            string randomPath = allImages[Random.Range(0, allImages.Count)];
            plant.imagePathAssigned = randomPath;

            Debug.Log($"Plant {plant.name} got image: {randomPath}");

            var prediction = await TomatoClassifier.ClassifyAsync(randomPath);

            if (prediction == null)
            {
                Debug.LogError($"Prediction failed for plant {plant.name}");
                continue;
            }

            count++;

            plant.predictedClassName = prediction.predicted_class_name;
            plant.hasBeenClassified = true;
            plant.isInfected = prediction.predicted_class_name != "Fruit healthy";

            Debug.Log($"{plant.name} -> {prediction.predicted_class_name} (infected = {plant.isInfected})");
        }

        Debug.Log($"Finished classifying all plants, {count} of {plants.Length}"); 
    }



    private void AddImagesFromFolder(string folder, List<string> list)
    {
        if (!Directory.Exists(folder))
        {
            Debug.LogWarning("Folder does not exist: " + folder);
            return;
        }

        // Agrega .jpg, .jpeg, .png
        string[] files = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);
        foreach (var f in files)
        {
            string ext = Path.GetExtension(f).ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
            {
                list.Add(f);
            }
        }
    }
}
