using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class PredictionResponse
{
    // OJO: los nombres deben coincidir con el JSON ("predicted_class_index", etc.)
    public int predicted_class_index;
    public string predicted_class_name;
}

public static class TomatoClassifier
{
    private static readonly HttpClient client = new HttpClient();

    // Endpoint real del modelo (no /docs)
    private const string Url = "http://127.0.0.1:80/predict";

    public static async Task<PredictionResponse> ClassifyAsync(string imagePath)
    {
        try
        {
            if (!File.Exists(imagePath))
            {
                Debug.LogError($"Image not found: {imagePath}");
                return null;
            }

            using var content = new MultipartFormDataContent();

            var imageBytes = File.ReadAllBytes(imagePath);
            var imageContent = new ByteArrayContent(imageBytes);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            content.Add(imageContent, "file", Path.GetFileName(imagePath));

            var response = await client.PostAsync(Url, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Debug.Log("Raw prediction JSON: " + json);

            // Aquí usamos el JsonUtility de Unity
            var prediction = JsonUtility.FromJson<PredictionResponse>(json);

            return prediction;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error calling classifier: {ex.Message}");
            return null;
        }
    }
}