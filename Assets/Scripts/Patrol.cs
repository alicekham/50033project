using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private int currentWP;
    private NavMeshAgent agent;
    private float waitTime;
    private float startWaitTime;
    private Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentWP = 0;
        Debug.Log("Patrol starts...");
    }

    void Update()
    {
        // agent.SetDestination(new Vector3(1.0f,5.0f,transform.position.z));
        Debug.Log("Update starts...");
        agent.SetDestination(wayPoints[currentWP].transform.position);
        Debug.Log("Update: " + currentWP);
        
        // check if it has reached the stop
        if(Vector2.Distance(transform.position, wayPoints[currentWP].position) < 0.2f) {
            if (waitTime<=0) {
                // move to new location
                currentWP += 1;
                if (currentWP == (wayPoints.Length-1))
                {
                    currentWP = 0;
                }
                waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
        Debug.Log("Update end...");
    }
}

