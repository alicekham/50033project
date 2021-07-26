using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daughterController : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D daughterBody;
    private SpriteRenderer daughterSprite;
    private float Horizontal, Vertical;
    private bool walkState;
    private  Animator daughterAnimator;
    private Vector2 moveDir;


    public GameObject basketball;
    public Rigidbody2D basketballBody;
    private string throwdir;
    public float throwspeed = 5;
    

    GameObject GetChildWithName(string name) {          
        Transform trans = this.gameObject.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) {
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
    basketball = GetChildWithName("Basketball Holder");
    basketballBody = basketball.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {   // movement
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal != 0 || Vertical != 0) {
            daughterAnimator.SetFloat("Horizontal", Horizontal);
            daughterAnimator.SetFloat("Vertical", Vertical);

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
                StopMoving();
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
        if (Input.GetKeyDown("m")) {
            basketball.SetActive(true);
            if (throwdir == "up") {
            basketball.transform.localPosition = new Vector3(0, 1, 0);
            basketballBody.AddForce(Vector2.up * throwspeed, ForceMode2D.Impulse);
            }
            else if (throwdir == "down") {
                basketball.transform.localPosition = new Vector3(0, -1, 0);
                basketballBody.AddForce(Vector2.down * throwspeed, ForceMode2D.Impulse);
            }
            else if (throwdir == "left") {
                basketball.transform.localPosition = new Vector3(-1, 0, 0);
                basketballBody.AddForce(Vector2.left * throwspeed, ForceMode2D.Impulse);
            }
            else {
                basketball.transform.localPosition = new Vector3(1, 0, 0);
                basketballBody.AddForce(Vector2.right * throwspeed, ForceMode2D.Impulse);
            }


        }


    }

    private void StopMoving() {
        daughterBody.velocity = Vector3.zero;
    }

    void FixedUpdate() 
    {
    // daughterBody.velocity = moveDir * speed * Time.deltaTime;
    daughterBody.MovePosition(daughterBody.position + (moveDir * speed * Time.fixedDeltaTime));
}
}