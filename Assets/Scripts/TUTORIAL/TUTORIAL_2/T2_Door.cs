using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class T2_Door : MonoBehaviour
{
    public NavMeshObstacle doorObstacle;
    public GameObject doorObject;
    public Rigidbody2D mumBody;
    private float distFromMum;
    public Rigidbody2D doorBody;

    void Start()
    {   
        // obstacle is present
        doorObstacle.carving = true;
    }

    void Update()
    {
        // obstacle is present
        distFromMum = Vector2.Distance(mumBody.transform.position, doorBody.transform.position);
        Debug.Log(distFromMum);
        
        if(Input.GetKeyDown(KeyCode.Return) && distFromMum < 1.0f)
        {
            Debug.Log("Mum opened a door!");
            // this door
            doorObject.SetActive(false);
            doorObstacle.carving = false;
        }   
    }
}