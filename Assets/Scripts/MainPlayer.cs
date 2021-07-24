using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* WITH COLLISION */

public class MainPlayer : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public NavMeshAgent humanAgent;
    public Rigidbody2D humanBody;
    public Rigidbody2D ghostBody;
    public GameObject ghostGameObject;
    private Rigidbody2D rb;
    private bool ishumanBody = false;
    private float dist;
    private Transform rbTransform;

    // Start is called before the first frame update
    void Start()
    {
        humanBody.isKinematic = true;
        ghostBody.isKinematic = true;
        rb = ghostBody;
        rbTransform = ghostBody.transform;
        
    }
    void Update()
    {
        dist = Vector2.Distance(humanBody.transform.position, ghostBody.transform.position);
        // Debug.Log(dist);

        if (dist<1.2f)
        {
            //Debug.Log("less than 1.2f!");
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && dist<1.2f)
        {
            ishumanBody = true;
        }

        if(rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Eject!");
            ishumanBody = false;
            ghostBody.transform.position = humanBody.transform.position - Vector3.right;
        }

  
    }

    // Movement
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (ishumanBody == true)
        {
            if (rb == ghostBody)
            {
                rb.velocity = Vector2.zero;
                rb = humanBody;
                humanAgent.isStopped = true;
                ghostGameObject.SetActive(false);
            }
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform = humanBody.transform;
            // Debug.Log(rb.tag);
            // Debug.Log(movement.y);
            // Debug.Log(rb.transform.position.y);

            // rb.transform.position = rb.transform.position + new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);
        }
        
        if (ishumanBody == false)
        {
            if (rb == humanBody)
            {
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                humanAgent.isStopped = false;
                ghostGameObject.SetActive(true);
            }
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform = humanBody.transform;
            // Debug.Log(rb.tag);
            // Debug.Log(movement.y);
            // Debug.Log(rb.transform.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision occured!");
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Collided with Chost");
        }
    }
}
