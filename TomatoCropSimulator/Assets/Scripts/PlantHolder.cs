using UnityEngine;

public class PlantHolder : MonoBehaviour
{
    [Header("Image assigned automatically")]
    public string imagePathAssigned;

    [Header("Classification info")]
    public bool hasBeenClassified = false;
    public bool isInfected = false;
    public string predictedClassName;

    [Header("Visuals")]

    public Renderer plantRenderer;
    public Color healthyColor = Color.green;
    public Color infectedColor = Color.red;

    public Color gizmoColorHealthy = Color.green;
    public Color gizmoColorInfected = Color.red;

    public void ApplyColorFromInfection()
    {
        if (plantRenderer == null) return;
        if (!hasBeenClassified) return;

        plantRenderer.material.color = isInfected ? infectedColor : healthyColor;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = hasBeenClassified && isInfected ? gizmoColorInfected : gizmoColorHealthy;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.5f, 0.2f);
    }
}