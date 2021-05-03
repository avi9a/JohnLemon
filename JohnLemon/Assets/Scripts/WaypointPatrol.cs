using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoint;
    int waypointIndex;
    // Start is called before the first frame update
    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoint[0].position);
    }

    // Update is called once per frame
    void Update() {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance) {
            waypointIndex = (waypointIndex + 1) % waypoint.Length;
            navMeshAgent.SetDestination(waypoint[waypointIndex].position);
        }
    }
}
