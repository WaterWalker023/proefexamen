using UnityEngine;
using UnityEngine.AI;

public class NavigationNPC : MonoBehaviour
{
    public GameObject[] waypointList;
    
    public int waypointIndex = 0;
    
    private NavMeshAgent agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypointIndex = Random.Range(0, waypointList.Length);
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Vector3.MoveTowards(transform.position, waypointList[waypointIndex].transform.position, 10);

        if (agent.remainingDistance < 1)
        {
            waypointIndex = Random.Range(0, waypointList.Length);
        }
    }
}
