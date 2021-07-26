using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10;
    private Rigidbody2D daughterBody;
    private SpriteRenderer daughterSprite;
    private float Horizontal, Vertical;
    private bool walkState;
    private  Animator daughterAnimator;
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        daughterSprite = GetComponent<SpriteRenderer>();
        daughterBody = GetComponent<Rigidbody2D>();
        daughterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
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
    }

    private void StopMoving() {
        daughterBody.velocity = Vector3.zero;
    }

    void FixedUpdate() 
    {
        daughterBody.velocity = moveDir * speed * Time.deltaTime;
    }   
}
