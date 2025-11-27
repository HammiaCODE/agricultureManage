using UnityEngine;

public class Detection : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        float maxDistance = 20f;
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        if(Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            Debug.Log("Distance: " + hit.distance);
            Debug.Log("Impact point: " + hit.point);


            Infection script = hit.collider.gameObject.GetComponent<Infection>();
            Debug.Log("Variable from hit object: " + script.infected);

            if (script.infected)
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            } else
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }
}
