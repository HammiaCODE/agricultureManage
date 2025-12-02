using UnityEngine;

public class CropSentrySensor : MonoBehaviour
{
    [Header("Raycast settings")]
    public float rayDistance = 2f;
    public float rayCooldown = 0.001f;

    private float nextRayTime = 0f;

    private void Update()
    {
        if (Time.time < nextRayTime)
            return;

        nextRayTime = Time.time + rayCooldown;

        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.right; // izquierda

        if (Physics.Raycast(origin, direction, out hit, rayDistance))
        {
            PlantHolder plant = hit.collider.GetComponent<PlantHolder>();

            if (plant != null && plant.hasBeenClassified)
            {
                Debug.Log($"CropSentry sees plant {plant.name} | infected = {plant.isInfected}");

                if (plant.isInfected)
                {
                    // Implement cropping
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 origin = transform.position;
        Vector3 direction = transform.right * rayDistance;
        Gizmos.DrawRay(origin, direction);
    }
}