using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/* WITH COLLISION */

public class MainPlayer : MonoBehaviour
{
    public Vector2 speed;
    private Vector2 movement;
    public NavMeshAgent humanAgent;
    public Rigidbody2D humanBody;
    public Rigidbody2D ghostBody;
    public Rigidbody2D toyCarBody;
    public GameObject ghostGameObject;
    public GameObject bookObject;
    private Rigidbody2D rb;
    private bool ishumanBody = false;
    private bool isToyCarBody = false;
    private float distWithHuman;
    private float distWithToyCar;
    private Transform rbTransform;
    public MeshRenderer MotherFOV;

    public UnityEvent onPossess;
    public UnityEvent onStopPossess;

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
        distWithHuman = Vector2.Distance(humanBody.transform.position, ghostBody.transform.position);
        distWithToyCar = Vector2.Distance(toyCarBody.transform.position, ghostBody.transform.position);
        // Debug.Log(dist);

        
        if(Input.GetKeyDown(KeyCode.Space) && distWithHuman < 1.2f)
        {
            ishumanBody = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && distWithToyCar < 1.2f)
        {
            isToyCarBody = true;
        }

        if (rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Eject!");
            ishumanBody = false;
            ghostBody.transform.position = humanBody.transform.position - Vector3.right;
        }
        if (rb.CompareTag("Object") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Eject!");
            isToyCarBody = false;
            ghostBody.transform.position = toyCarBody.transform.position - Vector3.left;
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
                onPossess.Invoke();
                MotherFOV.enabled = false;
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

        if (isToyCarBody == true)
        {
            if (rb == ghostBody)
            {
                onPossess.Invoke();
                rb.velocity = Vector2.zero;
                rb = toyCarBody;
                ghostGameObject.SetActive(false);
            }
            
            
            if (rb.position.x > 5.48f & rb.position.x < 9.88f)
            {
                rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
                rbTransform = humanBody.transform;
            }
            else
            {
                if (movement.x > 0f & rb.position.x < 5.48f)
                {
                    rb.MovePosition(rb.position + (movement.x * speed * Time.fixedDeltaTime));
                    rbTransform = humanBody.transform;
                }
                else if (rb.position.x > 9.88f)
                {
                    bookObject.SetActive(true);
                }
            }
            
            
            // Debug.Log(rb.tag);
            // Debug.Log(movement.y);
            // Debug.Log(rb.transform.position.y);

            // rb.transform.position = rb.transform.position + new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);
        }

        if (ishumanBody == false)
        {
            if (rb == humanBody)
            {
                onStopPossess.Invoke();
                MotherFOV.enabled = true;
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                humanAgent.isStopped = false;
                ghostGameObject.SetActive(true);
            }
            if (rb != toyCarBody)
            { 
                rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
                rbTransform = humanBody.transform;
            }
            // Debug.Log(rb.tag);
            // Debug.Log(movement.y);
            // Debug.Log(rb.transform.position.y);
        }

        if (isToyCarBody == false)
        {
            if (rb == toyCarBody)
            {
                onStopPossess.Invoke();
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                ghostGameObject.SetActive(true);
            }

            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform = humanBody.transform;
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision occured!");
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Collided with Chost");
        }
        if (other.gameObject.CompareTag("Object"))
        {
            Debug.Log("Collided with Object");
        }
    }
}
