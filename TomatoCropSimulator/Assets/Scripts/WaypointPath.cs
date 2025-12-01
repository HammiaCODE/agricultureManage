using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Color sphereColor = Color.red;
    public enum PathType
    {
        Loop, ReverseWhenComplete
    }

    public Transform[] waypoints;
    public PathType pathType = PathType.Loop;

    private int direction = 1;
    private int index = 0;

    public Vector3 GetCurrentWayPoint()
    {
        return waypoints[index].position;
    }
    public Vector3 GetNextWayPoint()
    {
        if(waypoints.Length == 0) return transform.position;

        index = GetNextWayPointIndex();
        Vector3 nextWayPoint = waypoints[index].position;
        
        return nextWayPoint;
    }

    private int GetNextWayPointIndex()
    {
        index += direction;

        if(pathType == PathType.Loop)
        {
            index %= waypoints.Length;
        }else if(pathType == PathType.ReverseWhenComplete)
        {
            if(index >= waypoints.Length || index < 0)
            {
                direction *= -1;
                index += direction * 2;
            }
        }

        return index;
    }

    private void OnDrawGizmos()
    {
        if(waypoints == null || waypoints.Length == 0) return;

        for(int i = 0; i<waypoints.Length-1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i+1].position);
        }

        if(pathType == PathType.Loop)
        {
            Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);
        }

        Gizmos.color = sphereColor;

        foreach(Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, .2f);
        }
    }
}
