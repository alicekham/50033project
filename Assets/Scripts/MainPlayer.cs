using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainPlayer : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    [SerializeField] Rigidbody2D[] humanBody;
    private int humanPossessed;
    private Rigidbody2D currentHumanBody;
    private NavMeshAgent currentHumanAgent;
    [SerializeField] NavMeshAgent[] humanAgent;
    public Rigidbody2D ghostBody;
    public GameObject ghostGameObject;
    private Rigidbody2D rb;
    private bool ishumanBody = false;
    private float dist;
    private Transform rbTransform;

    // Start is called before the first frame update
    void Start()
    {
        rbTransform = GetComponent<Transform>();
        ghostBody.isKinematic = true;
        rb = ghostBody;
        rbTransform = ghostBody.transform;
        Debug.Log("rbPosition" + rbTransform);
    }

    void Update()
    {
        int i;
        for (i=0;i<humanBody.Length;i++)
        {
            dist = Vector2.Distance(humanBody[i].transform.position, ghostBody.transform.position);
            // Debug.Log(dist);

            if (dist<1.2f)
            {
                //Debug.Log("less than 1.2f!");
            }
            
            if(Input.GetKeyDown(KeyCode.Space) && dist<1.2f)
            {
                ishumanBody = true;
                currentHumanBody = humanBody[i];
                currentHumanAgent = humanAgent[i];
            }

            if(rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("Eject!");
                ishumanBody = false;
                ghostBody.transform.position = currentHumanBody.transform.position - Vector3.right;
            }
        }

        /*
        dist = Vector2.Distance(humanBody[humanPossessed].transform.position, ghostBody.transform.position);
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
            ghostBody.transform.position = humanBody[humanPossessed].transform.position - Vector3.right;
        }
        */
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
                rb = currentHumanBody;
                currentHumanAgent.isStopped = true;
                ghostGameObject.SetActive(false);
            }
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform.position = rb.transform.position;
        }
        
        if (ishumanBody == false)
        {   
            if (rb == currentHumanBody)
            {
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                currentHumanAgent.isStopped = false;
                ghostGameObject.SetActive(true);
            }
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform.position = rb.transform.position;
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
