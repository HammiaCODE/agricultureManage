using UnityEngine;
using TMPro;

public class DepositArea : MonoBehaviour
{
    private int tomatoCount = 0;
    private int infectedCount = 0;

    public TMP_Text tomatoesColected;
    public TMP_Text infectedColected;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject harvester = collision.gameObject;

        Harvest harvest = harvester.GetComponent<Harvest>();

        tomatoCount += harvest.tomatoesCarried;
        harvest.tomatoesCarried = 0;
        tomatoesColected.text = "Tomatoes Colected " + tomatoCount;

        infectedCount += harvest.infectedCarried;
        harvest.infectedCarried = 0;
        tomatoesColected.text = "Tomatoes Colected " + tomatoCount;
        infectedColected.text = "Infected Colected " + infectedCount;
    }
}
