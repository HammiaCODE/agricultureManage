using UnityEngine;

public class Harvest : MonoBehaviour
{
    public int tomatoesCarried;
    public int infectedCarried;

    public float rayDistance = 3f;
    public int reverse = 1;
    public LayerMask plantLayer;

     private float cooldown = .05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0f)
        {
            HarvestPlant();
        }
    }

    private void HarvestPlant()
    {
        RaycastHit hit;

        Vector3 origin = transform.position;
        Vector3 direction = transform.right * reverse;
        
        Debug.DrawRay(origin, direction * rayDistance, Color.red);

        if (Physics.Raycast(origin, direction, out hit, rayDistance, plantLayer))
        {
            PlantHolder plant = hit.collider.GetComponentInParent<PlantHolder>();
            if (plant != null)
            {
                switch(plant.HarvestFruit())
                {
                    case 0:
                        break;
                    case 1:
                        tomatoesCarried++;
                        break;
                    case 2:
                        infectedCarried++;
                        break;
                }
                cooldown = .2f;
            }
        }
    }

    // sees a plant with tomatoe collects it
        //use a raycast
    // when in deposit area deposits carried tomatoes
        // on collision trigger
}
