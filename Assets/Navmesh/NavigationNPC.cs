using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationNPC : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypointList;

    [SerializeField] private int waypointIndex = 0;
    
    private NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypointIndex = Random.Range(0, waypointList.Count);
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            waypointIndex = Random.Range(0, waypointList.Count);

            agent.destination = waypointList[waypointIndex].transform.position;
        }
    }
}
