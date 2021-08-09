using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Openable_Doors : MonoBehaviour
{
    [SerializeField] NavMeshObstacle[] doorObstacles;
    [SerializeField] GameObject[] doorObjects;
    public Rigidbody2D mumBody;
    private float distFromMum;
    [SerializeField] Rigidbody2D[] doorBodies;

    void Start()
    {
        for (int i=0; i<doorObstacles.Length; i++)
        {
            // obstacle is present
            doorObstacles[i].carving = true;
        }
    }

    void Update()
    {
        for (int i=0; i<doorBodies.Length; i++)
        {
            // obstacle is present
            distFromMum = Vector2.Distance(mumBody.transform.position, doorBodies[i].transform.position);

            if(Input.GetKeyDown("m") && distFromMum < 2.0f)
            {
                Debug.Log("Mum opened a door!");
                for (int j=0; j<doorBodies.Length; j++)
                {
                    // other doors
                    doorObjects[j].SetActive(true);
                    doorObstacles[j].carving = true;
                }
                // this door
                doorObjects[i].SetActive(false);
                doorObstacles[i].carving = false;
            }   
        }
    }
}