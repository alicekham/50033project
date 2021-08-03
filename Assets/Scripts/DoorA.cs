using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorA : MonoBehaviour
{
    private NavMeshObstacle doorObstacle;
    public GameObject doorObject;
    Animator doorAnimator;
    // private AudioSource openSound;
    public Rigidbody2D mumBody;
    private float distFromMum;
    private Rigidbody2D doorBody;
    // Start is called before the first frame update
    void Start()
    {
        doorObstacle = GetComponent<NavMeshObstacle>();
        // doorAnimator = GetComponent<Animator>();
        // openSound = GetComponent<AudioSource>();
        doorBody = GetComponent<Rigidbody2D>();
        doorObject = GetComponent<GameObject>();
        doorObstacle.carving = true;
    }

    // Update is called once per frame
    void Update()
    {
        distFromMum = Vector2.Distance(mumBody.transform.position, doorBody.transform.position);
        // Debug.Log("distFromMum: " + distFromMum);
        if(Input.GetKeyDown("m") && distFromMum < 2.0f)
        {
            Debug.Log("mum is trying to open the door!");
            doorObject.SetActive(false);
            // doorAnimator.SetTrigger("Open");
            doorObstacle.carving = false;
        }
    }
}