using UnityEngine;
using UnityEngine.AI;

public class SentryPath : MonoBehaviour
{
    [SerializeField] private WaypointPath path;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private Transform home;

    private float time = 0f;
    private NavMeshAgent agent;

    private bool movementEnabled = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.isStopped = true;
    }

    void Update()
    {
        if(!movementEnabled) return;

        if(!agent.pathPending && agent.remainingDistance <= 0.1f)
        {
            time += Time.deltaTime;

            if(time >= waitTime)
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
        agent.destination = home.position;
        //agent.isStopped = true;
    }
}
