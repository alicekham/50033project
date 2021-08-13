using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class T2_MainPlayer : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public Rigidbody2D ghostBody;
    public Rigidbody2D humanBody;
    public GameObject ghostGameObject;
    private Rigidbody2D rb;
    private float dist;
    private Transform rbTransform;
    private bool isHumanBody;
    public NavMeshAgent humanAgent;
    public Collider2D humanCollider;
    public GameObject humanLight;

    // Start is called before the first frame update
    void Start()
    {
        ghostBody.isKinematic = true;
        rb = ghostBody;
        
        rbTransform = GetComponent<Transform>();
        rbTransform.position = ghostBody.transform.position;
        Debug.Log("rbPosition" + rbTransform);
        humanAgent.enabled = false;
        //humanCollider.enabled = false;
        
    }

    void Update()
    {
        dist = Vector2.Distance(humanBody.transform.position, ghostBody.transform.position);
        
        if(Input.GetKeyDown(KeyCode.Space) && dist<1.2f)
        {
            isHumanBody = true;
        }

        if(rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Eject!");
            isHumanBody = false;
            ghostBody.transform.position = humanBody.transform.position - Vector3.right;
        }
    }

    // Movement
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (isHumanBody == true)
        {
            if (rb == ghostBody)
            {
                rb.velocity = Vector2.zero;
                rb = humanBody;
                ghostGameObject.SetActive(false);
            }

            humanAgent.enabled = true;
            // humanCollider.enabled = true;
            // for camera
            rbTransform.position = rb.transform.position;
            //Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform.position = rb.transform.position;
            humanLight.SetActive(true);
            
        }
        
        if (isHumanBody == false)
        {   
            if (rb == humanBody)
            {
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                ghostGameObject.SetActive(true);
            }

            humanAgent.enabled = false;
            // humanCollider.enabled = false;
            // for camera
            rbTransform.position = rb.transform.position;
            //Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform.position = rb.transform.position;
            humanLight.SetActive(false);
        }
    }
}