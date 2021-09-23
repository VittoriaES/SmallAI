using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TobyManager : MonoBehaviour
{
    private NavMeshAgent agent;

    public List<TargetPoint> targetPoints = new List<TargetPoint>();

    public int indexNextDestination;
    private Vector3 actualDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(1, 100);
        agent.speed = Random.Range(1, 6);
        NextDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance <= agent.stoppingDistance) {
            NextDestination();
        }
    }

    private void NextDestination() {

        int oldIndex = indexNextDestination;
        while (oldIndex == indexNextDestination && targetPoints.Count > 1) {
            indexNextDestination = Random.Range(0, targetPoints.Count);
        }
        
        TargetPoint tp = targetPoints[indexNextDestination];
        actualDestination = tp.GivePoint();
        agent.SetDestination(actualDestination);
    }

    private void OnDrawGizmos() {
        if (agent != null) {
            Gizmos.DrawSphere(transform.position + Vector3.up * 2, 0.05f + ((100 - agent.avoidancePriority) * 0.01f));
        }
        
    }
    
}
