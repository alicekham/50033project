using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class T4_MainPlayer : MonoBehaviour
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

    public GameObject basketball;
    public Rigidbody2D basketballBody;
    private string throwdir;
    public float throwspeed = 5;
    // private AudioSource bounceSound;

    // Start is called before the first frame update
    void Start()
    {
        ghostBody.isKinematic = true;
        rb = ghostBody;
        
        rbTransform = GetComponent<Transform>();
        rbTransform.position = ghostBody.transform.position;
        Debug.Log("rbPosition" + rbTransform);
        humanAgent.enabled = false;
        // humanCollider.enabled = false;
        
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
            ghostBody.transform.position = humanBody.transform.position - Vector3.left;
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

            // for camera
            rbTransform.position = rb.transform.position;
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
            rbTransform.position = rb.transform.position;
            humanLight.SetActive(true);

            //get direction to throw
        
            if (movement.x == -1 && movement.y == 0) {throwdir = "left";}
            else if (movement.x == 1 && movement.y == 0) {throwdir = "right";}
            else if (movement.y == 1) {throwdir = "up";}
            else if (movement.y == -1) {throwdir = "down";}
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                basketball.SetActive(true);
                StartCoroutine(throwBall());
            }

            IEnumerator throwBall()
            {
                if (throwdir == "up")
                {
                    // bounceSound.PlayOneShot(bounceSound.clip);
                    basketball.transform.localPosition = new Vector3(0, 0.5f, 0);
                    for (int i = 0; i < 7; i++)
                    {
                        //basketballBody.AddForce(Vector2.up * throwspeed, ForceMode2D.Impulse);

                        basketball.transform.localPosition += new Vector3(0, 0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    basketball.transform.localPosition = new Vector3(0, 0, 0);
                    basketball.SetActive(false);
                    yield break;
                }
                else if (throwdir == "down")
                {
                    // bounceSound.PlayOneShot(bounceSound.clip);
                    basketball.transform.localPosition = new Vector3(0, -0.5f, 0);
                    for (int i = 0; i < 7; i++)
                    {
                        //basketballBody.AddForce(Vector2.up * throwspeed, ForceMode2D.Impulse);

                        basketball.transform.localPosition += new Vector3(0, -0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    basketball.transform.localPosition = new Vector3(0, 0, 0);
                    basketball.SetActive(false);
                    yield break;
                }
                else if (throwdir == "left")
                {
                    // bounceSound.PlayOneShot(bounceSound.clip);
                    basketball.transform.localPosition = new Vector3(-0.5f, 0, 0);
                    for (int i = 0; i < 7; i++)
                    {
                        //basketballBody.AddForce(Vector2.up * throwspeed, ForceMode2D.Impulse);

                        basketball.transform.localPosition += new Vector3(-0.25f, 0, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    basketball.transform.localPosition = new Vector3(0, 0, 0);
                    basketball.SetActive(false);
                    yield break;
                }
                else
                {
                    // bounceSound.PlayOneShot(bounceSound.clip);
                    basketball.transform.localPosition = new Vector3(0.5f, 0, 0);
                    for (int i = 0; i < 7; i++)
                    {
                        //basketballBody.AddForce(Vector2.up * throwspeed, ForceMode2D.Impulse);

                        basketball.transform.localPosition += new Vector3(0.25f, 0, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    basketball.transform.localPosition = new Vector3(0, 0, 0);
                    basketball.SetActive(false);
                    yield break;
                }
            }
        }

        if (isHumanBody == false)
        {   
            if (rb == humanBody)
            {
                rb.velocity = Vector2.zero;
                rb = ghostBody;
                ghostGameObject.SetActive(true);
                basketball.SetActive(false);
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