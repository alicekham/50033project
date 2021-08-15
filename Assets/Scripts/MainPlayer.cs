using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MainPlayer : MonoBehaviour
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

    public GameObject MotherLight;
    public GameObject ButlerLight;
    public GameObject SisterLight;
    public GameObject TrainLight;

    public UnityEvent onPossess;
    public UnityEvent onStopPossess;

    private Transform rbTransform;

    public AudioSource Bark;
    private AudioClip barkSound;
    private int barkCounter = 0;
    private bool BookFell = false;
    private int barkCounter2 = 0;

    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line3Ghost;
    public GameObject Line4Ghost;
    public GameObject Line5Ghost;
    public GameObject Line2;
    public GameObject Line4;

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
        barkSound = Bark.GetComponent<AudioSource>().clip;
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
                if (gameConstants.isMother)
                {
                    MotherFOV.enabled = false;
                    MotherLight.SetActive(true);
                }
                if (gameConstants.isButler)
                {
                    ButlerFOV.enabled = false;
                    ButlerLight.SetActive(true);
                }
                if (gameConstants.isSister)
                {
                    SisterFOV.enabled = false;
                    SisterLight.SetActive(true);
                }
                rb.velocity = Vector2.zero;
                rb = currentHumanBody;
                // currentHumanAgent.enabled = false;
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
                TrainLight.SetActive(true);
            }
            if (rb.position.x > 5.48f & rb.position.x < 9.88f)
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
                    barkCounter++;
                    BookFell = true;
                    bookObject.SetActive(true);
                    if (barkCounter == 1) {
                        GhostChatQuest1.SetActive(true);
                        GhostChatQuest2.SetActive(false);
                        GhostChatQuest3.SetActive(false);

                        Line3Ghost.SetActive(false);
                        Line4Ghost.SetActive(true);
                        Bark.PlayOneShot(barkSound);
                        Line2.SetActive(false);
                        Line4.SetActive(true);
                    }

                }
            }
        }
        if (BookFell)
        {
            barkCounter2++;
            Debug.Log(barkCounter2);
            if (barkCounter2 == 120)
            {
                GhostChatQuest1.SetActive(true);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(false);

                Bark.PlayOneShot(barkSound);
                Line4Ghost.SetActive(false);
                Line5Ghost.SetActive(true);
            }

        }

        if (ishumanBody == false)
        {   
            if (rb == currentHumanBody)
            {
                onStopPossess.Invoke();
                if (!gameConstants.isMother)
                {
                    MotherFOV.enabled = true;
                    MotherLight.SetActive(false);
                }
                if (!gameConstants.isButler)
                {
                    ButlerFOV.enabled = true;
                    ButlerLight.SetActive(false);
                }
                if (!gameConstants.isSister)
                {
                    SisterFOV.enabled = true;
                    SisterLight.SetActive(false);
                }
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                // currentHumanAgent.enabled = true;
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
                TrainLight.SetActive(false);
            }
            rbTransform.position = rb.transform.position;
            //Debug.Log("rbTransform: " + rbTransform);
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }
    }

    private void OnApplicationQuit()
    {
        gameConstants.isMother = false;
        gameConstants.isButler = false;
        gameConstants.isSister = false;
    }
}