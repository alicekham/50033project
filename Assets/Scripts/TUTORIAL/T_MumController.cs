using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class T_MumController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;

    public GameConstants gameConstants;

    [SerializeField] Rigidbody2D[] humanBody;
    private int humanPossessed;

    private Rigidbody2D currentHumanBody;
    private NavMeshAgent currentHumanAgent;
    [SerializeField] NavMeshAgent[] humanAgent;

    public Rigidbody2D ghostBody;
    public GameObject ghostGameObject;

    public Rigidbody2D toyCarBody;
    public GameObject bookObject;

    private Rigidbody2D rb;

    private bool ishumanBody = false;
    private bool isToyCarBody = false;

    private float distWithHuman;
    private float distWithToyCar;

    public MeshRenderer MotherFOV;
    public MeshRenderer ButlerFOV;
    public MeshRenderer SisterFOV;

    public UnityEvent onPossess;
    public UnityEvent onStopPossess;

    private Transform rbTransform;


     private AudioSource possessAudio;
    // Start is called before the first frame update
    void Start()
    {
        ghostBody.isKinematic = true;
        rb = ghostBody;
        rbTransform = GetComponent<Transform>();
        rbTransform.position = ghostBody.transform.position;
        //Debug.Log("rbTransform: " + rbTransform);
        possessAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        int i;
        for (i=0;i<humanBody.Length;i++)
        {
            distWithHuman = Vector2.Distance(humanBody[i].transform.position, ghostBody.transform.position);
            distWithToyCar = Vector2.Distance(toyCarBody.transform.position, ghostBody.transform.position);
            // Debug.Log("dist (human): " + distWithHuman);
            
            if(Input.GetKeyDown(KeyCode.Space) && distWithHuman < 1.2f)
            {
                ishumanBody = true;
                humanPossessed = i;
                currentHumanBody = humanBody[i];
                currentHumanAgent = humanAgent[i];
                if (i == 0) gameConstants.isMother = true;
                if (i == 1) gameConstants.isButler = true;
                if (i == 2) gameConstants.isSister = true;
                possessAudio.PlayOneShot(possessAudio.clip);
            }
            if (Input.GetKeyDown(KeyCode.Space) && distWithToyCar < 1.2f)
            {
                isToyCarBody = true;
                possessAudio.PlayOneShot(possessAudio.clip);
            }

            if (rb.CompareTag("Human") && Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("Eject!");
                ishumanBody = false;
                gameConstants.isMother = false;
                gameConstants.isButler = false;
                gameConstants.isSister = false;
                ghostBody.transform.position = currentHumanBody.transform.position - Vector3.right;
            }
            if (rb.CompareTag("Object") && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Eject!");
                isToyCarBody = false;
                ghostBody.transform.position = toyCarBody.transform.position - Vector3.left;
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
                onPossess.Invoke();
                if (gameConstants.isMother) MotherFOV.enabled = false;
                if (gameConstants.isButler) ButlerFOV.enabled = false;
                if (gameConstants.isSister) SisterFOV.enabled = false;
                rb.velocity = Vector2.zero;
                rb = currentHumanBody;
                currentHumanAgent.isStopped = true;
                // currentHumanAgent.updatePosition = false;
                ghostGameObject.SetActive(false);
            }

            // for camera
            rbTransform.position = rb.transform.position;
            //Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }

        if (isToyCarBody == true)
        {
            if (rb == ghostBody)
            {
                onPossess.Invoke();
                rb.velocity = Vector2.zero;
                rb = toyCarBody;
                ghostGameObject.SetActive(false);
            }if (rb.position.x > 5.48f & rb.position.x < 9.88f)
            {
                rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            }
            else
            {
                if (movement.x > 0f & rb.position.x < 5.48f)
                {
                    rb.MovePosition(rb.position + (new Vector2(movement.x,0) * speed * Time.fixedDeltaTime));
                }
                else if (rb.position.x > 9.88f)
                {
                    bookObject.SetActive(true);
                }
            }
        }

        if (ishumanBody == false)
        {   
            if (rb == currentHumanBody)
            {
                onStopPossess.Invoke();
                if (!gameConstants.isMother) MotherFOV.enabled = true;
                if (!gameConstants.isButler) ButlerFOV.enabled = true;
                if (!gameConstants.isSister) SisterFOV.enabled = true;
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                currentHumanAgent.isStopped = false;
                // currentHumanAgent.updatePosition = true;
                ghostGameObject.SetActive(true);
            }
            if (rb != toyCarBody)
            {
                rbTransform.position = rb.transform.position;
                //Debug.Log("rbTransform: " + rbTransform);
                rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            }
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
            rbTransform.position = rb.transform.position;
            //Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }
    }
}