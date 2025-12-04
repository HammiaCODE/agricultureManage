using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private SentryPath[] cropSentries;
    [SerializeField] private HarvesterPath[] harvesters;

    [SerializeField] private float cutDuration = 15f;
    [SerializeField] private float stopCutDuration = 25;
    [SerializeField] private float harvestDuration = 45f;
    
    private float cutTime;
    private float stopCutTime;
    private float harvestTime;

    private float cycleTimer = 0f; 
    
    private bool sentriesStarted = false;
    private bool sentriesStopped = false;
    private bool harvestersStarted = false;
    private bool harvestersStopped = false;
    
    void Update()
    {
        cycleTimer += Time.deltaTime;

        if (!sentriesStarted && cycleTimer >= cutTime)
        {
            StartSentries();
            sentriesStarted = true;
        }

        if (sentriesStarted && !sentriesStopped && cycleTimer >= stopCutTime)
        {
            StopSentries();
            sentriesStopped = true;

            StartHarvesters();
            harvestersStarted = true;
        }

        if (harvestersStarted && !harvestersStopped && cycleTimer >= harvestTime)
        {
            StopHarvesters();
            harvestersStopped = true;

            StartNewCycle();
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
        harvestersStarted = true;
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
        harvestersStopped = true;
        foreach (var agent in harvesters)
        {
            if (agent != null)
                agent.StopMovement();
        }
    }

    void StartNewCycle()
    {
        cycleTimer = 0f;

        sentriesStarted = false;
        sentriesStopped = false;
        harvestersStarted = false;
        harvestersStopped = false;

        cutTime = cutDuration;
        stopCutTime = cutDuration + stopCutDuration;
        harvestTime = cutDuration + stopCutDuration + harvestDuration;
    }
}

