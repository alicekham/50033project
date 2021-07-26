using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherController : MonoBehaviour
{   
    public float speed = 2;
    private Rigidbody2D mumBody;
    private SpriteRenderer mumSprite;
    private float Horizontal, Vertical;
    private bool walkState;
    private  Animator mumAnimator;
    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
    mumSprite = GetComponent<SpriteRenderer>();
    mumBody = GetComponent<Rigidbody2D>();
    mumAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal != 0 || Vertical != 0) {
            mumAnimator.SetFloat("Horizontal", Horizontal);
            mumAnimator.SetFloat("Vertical", Vertical);

            if (!walkState) {
                walkState = true;
                mumAnimator.SetBool("walkState", walkState);
            }
        }
        else
        {
            if (walkState) {
                walkState = false;
                mumAnimator.SetBool("walkState", walkState);
                StopMoving();
            }
        }
        moveDir = new Vector2(Horizontal,Vertical).normalized;
    }

    private void StopMoving() {
        mumBody.velocity = Vector3.zero;
    }

    void FixedUpdate() 
    {
    mumBody.MovePosition(mumBody.position + (moveDir * speed * Time.fixedDeltaTime));
    }   

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("door"))
        {
            Debug.Log("colliding with door");
        }
    }
}
