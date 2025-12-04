using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private SentryPath[] cropSentries;
    [SerializeField] private HarvesterPath[] harvesters;

    private float cutTime = 15f;
    private float stopCut = 30f;
    private float harvestTime = 127f;
    private float startCutTimer = 0f; 
    
    private bool sentriesStarted = false;
    private bool sentriesStopped = false;
    
    private bool harvesterStarted = false;
    private bool harvesterStopped = false;
    
    void Update()
    {
        startCutTimer += Time.deltaTime;
        if (!sentriesStarted && startCutTimer >= cutTime)
        {
            StartSentries();
        }
        
        // Stop sentries after stopCut
        if (sentriesStarted && !sentriesStopped && startCutTimer >= stopCut + cutTime)
        {
            StopSentries();
            StartHarvesters();
        }

        if (harvesterStarted && !harvesterStopped && startCutTimer >= harvestTime + cutTime + stopCut)
        {
            StopHarvesters();
        }
    }

    private void StartSentries()
    {
        sentriesStarted = true;
        foreach (var agent in cropSentries)
        {
            if (agent != null)
                agent.StartMovement();
        }
    }
    private void StartHarvesters()
    {
        harvesterStarted = true;
        foreach (var agent in harvesters)
        {
            if (agent != null)
                agent.StartMovement();
        }
    }
    
    private void StopSentries()
    {
        sentriesStopped = true;
        foreach (var agent in cropSentries)
        {
            if (agent != null)
                agent.StopMovement();
        }
    }

    private void StopHarvesters()
    {
        harvesterStopped = true;
        foreach (var agent in harvesters)
        {
            if (agent != null)
                agent.StopMovement();
        }
    }
}

