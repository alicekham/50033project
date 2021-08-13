using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T4_SisterController : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D daughterBody;
    private SpriteRenderer daughterSprite;
    private float Horizontal, Vertical;
    private bool walkState;
    private  Animator daughterAnimator;
    private Vector2 moveDir;
    private bool isSister;

    // [SerializeField] private FieldOfView fieldOfView;
    public GameConstants gameConstants;
    private Vector3 posn;
    private Vector3 newposn;
    private Vector3 dir;


    public GameObject basketball;
    public Rigidbody2D basketballBody;
    private string throwdir;
    public float throwspeed = 5;

    private AudioSource bounceSound;
    

    GameObject GetChildWithName(string name)
    {          
        Transform trans = this.gameObject.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        } else {
            return null;
        }
    }
    
    void Start()
    {
    daughterSprite = GetComponent<SpriteRenderer>();
    daughterBody = GetComponent<Rigidbody2D>();
    daughterAnimator = GetComponent<Animator>();
    posn = daughterBody.transform.localPosition;
    basketball = GetChildWithName("Basketball Holder");
    basketballBody = basketball.GetComponent<Rigidbody2D>();
    bounceSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {   //Update FOV
        newposn = daughterBody.transform.localPosition;
        dir = newposn - posn;
        posn = newposn;
        // // Debug.Log(dir);
        // fieldOfView.SetDirection(dir);
        // fieldOfView.SetOrigin(transform.position);

        // movement
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (dir.x != 0 || dir.y != 0) {
            daughterAnimator.SetFloat("Horizontal", dir.x);
            daughterAnimator.SetFloat("Vertical", dir.y);

            if (!walkState) {
                walkState = true;
                daughterAnimator.SetBool("walkState", walkState);
            }
        }
        else
        {
            if (walkState) {
                walkState = false;
                daughterAnimator.SetBool("walkState", walkState);
                daughterBody.velocity = Vector3.zero;
            }
        }
        moveDir = new Vector3(Horizontal,Vertical).normalized;

        //get direction to throw
    
        if (Horizontal == -1 && Vertical == 0) {
            throwdir = "left";
        }

        else if (Horizontal == 1 && Vertical == 0) {
            throwdir = "right";
        }

        else if (Vertical == 1) {
            throwdir = "up";
        }

        else if (Vertical == -1) {
            throwdir = "down";
        }

        //basketball throwing
         if (gameConstants.isSister == true)
         {
             if (Input.GetKeyDown(KeyCode.Return))
             {
                 basketball.SetActive(true);
                 StartCoroutine(throwBall());
             }
         }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            basketball.SetActive(true);
            StartCoroutine(throwBall());
        }

        IEnumerator throwBall()
            {

                if (throwdir == "up")
                {
                    bounceSound.PlayOneShot(bounceSound.clip);
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
                    bounceSound.PlayOneShot(bounceSound.clip);
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
                    bounceSound.PlayOneShot(bounceSound.clip);
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
                    bounceSound.PlayOneShot(bounceSound.clip);
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
}