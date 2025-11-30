using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private PathTraversion[] cropSentries;
    [SerializeField] private PathTraversion[] harvesters;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSentries();
        }
    }

    public void StartSentries()
    {
        foreach (var agent in cropSentries)
        {
            if (agent != null)
                agent.StartMovement();
        }
    }

    public void StartHarvesters()
    {
        foreach (var agent in harvesters)
        {
            if (agent != null)
                agent.StartMovement();
        }
    }

    public void StopAllAgents()
    {
        foreach (var agent in cropSentries)
        {
            if (agent != null)
                agent.StopMovement();
        }
        foreach (var agent in harvesters)
        {
            if (agent != null)
                agent.StopMovement();
        }
    }
}
