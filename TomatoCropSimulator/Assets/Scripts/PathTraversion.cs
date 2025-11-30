using UnityEngine;
using UnityEngine.AI;

public class PathTraversion : MonoBehaviour
{
    [SerializeField] private WaypointPath path;
    [SerializeField] private float waitTime = 1f;

    private float time = 0f;
    private NavMeshAgent agent;

    // Movement flag
    private bool movementEnabled = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        // Disable movement until manager triggers it
        agent.isStopped = true;
    }

    void Update()
    {
        if (!movementEnabled) return;

        if (!agent.pathPending && agent.remainingDistance <= 0.1f)
        {
            time += Time.deltaTime;

            if (time >= waitTime)
            {
                time = 0f;
                agent.destination = path.GetNextWayPoint();
            }
        }
    }

    public void StartMovement()
    {
        movementEnabled = true;
        agent.isStopped = false;
        agent.destination = path.GetCurrentWayPoint();
    }

    public void StopMovement()
    {
        movementEnabled = false;
        agent.isStopped = true;
    }
}
