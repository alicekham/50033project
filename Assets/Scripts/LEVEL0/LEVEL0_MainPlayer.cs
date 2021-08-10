using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class LEVEL0_MainPlayer : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    // public GameConstants gameConstants;

    [SerializeField] Rigidbody2D[] humanBody;
    private int humanPossessed;

    private Rigidbody2D currentHumanBody;
    private NavMeshAgent currentHumanAgent;
    [SerializeField] NavMeshAgent[] humanAgent;

    public Rigidbody2D ghostBody;
    public GameObject ghostGameObject;
    private Rigidbody2D rb;
    private bool ishumanBody = false;
  
    private float distWithHuman;

    public MeshRenderer MotherFOV;

    // public UnityEvent onPossess;
    // public UnityEvent onStopPossess;

    private Transform rbTransform;

    // private AudioSource possessAudio;
    // Start is called before the first frame update
    void Start()
    {
        ghostBody.isKinematic = true;
        rb = ghostBody;
        rbTransform = GetComponent<Transform>();
        rbTransform.position = ghostBody.transform.position;
        //Debug.Log("rbTransform: " + rbTransform);
        // possessAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        int i;
        for (i=0;i<humanBody.Length;i++)
        {
            distWithHuman = Vector2.Distance(humanBody[i].transform.position, ghostBody.transform.position);
            
            if(Input.GetKeyDown(KeyCode.Space) && distWithHuman < 1.2f)
            {
                ishumanBody = true;
                humanPossessed = i; 
                currentHumanBody = humanBody[i];
                currentHumanAgent = humanAgent[i];
                // if (i == 0) gameConstants.isMother = true;
                // possessAudio.PlayOneShot(possessAudio.clip);
            }
            
            if (rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("Eject!");
                ishumanBody = false;
                // gameConstants.isMother = false;
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
        Debug.Log(rb.name);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log(movement);

        if (ishumanBody == true)
        {
            if (rb == ghostBody)
            {
                // onPossess.Invoke();
                // if (gameConstants.isMother) MotherFOV.enabled = false;
                rb.velocity = Vector2.zero;
                rb = currentHumanBody;
                currentHumanAgent.isStopped = true;
                // currentHumanAgent.updatePosition = false;
                ghostGameObject.SetActive(false);
            }

            // for camera
            rbTransform.position = rb.transform.position;
            // Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }

        if (ishumanBody == false)
        {   
            if (rb == currentHumanBody)
            {
                // onStopPossess.Invoke();
                // if (!gameConstants.isMother) MotherFOV.enabled = true;
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                currentHumanAgent.isStopped = false;
                // currentHumanAgent.updatePosition = true;
                ghostGameObject.SetActive(true);
            }
            rbTransform.position = rb.transform.position;
            Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }
    }
}