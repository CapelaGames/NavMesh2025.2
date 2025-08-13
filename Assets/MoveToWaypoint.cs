using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveToWaypoint : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private int destinationIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[destinationIndex].position;
        destinationIndex = (destinationIndex + 1) % points.Length;
        /*
        0 % 3 = 0
        1 % 3 = 1
        2 % 3 = 2
        3 % 3 = 0
        */
    }
}
