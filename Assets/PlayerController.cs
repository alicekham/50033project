using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private bool faceLeftState = false;
    //private bool faceRightState = false;
    //private bool faceUpState = false;
    //private bool faceDownState = true;
    [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D ghostBody;
    private SpriteRenderer ghostSprite;
    public float speed;
    public float maxSpeed = 40f;
    public float moveHorizontal;
    public float moveVertical;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //Set Framerate to 30 FPS
        Application.targetFrameRate = 30;
        ghostBody = GetComponent<Rigidbody2D>();
        ghostSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = ghostBody.velocity;
        fieldOfView.SetDirection(dir);
        fieldOfView.SetOrigin(transform.position);
    }

    void FixedUpdate()
    {
        // dynamic rigidbody
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        
        // Limit Mario's Horizontal Max Speed
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            Vector2 movementHor = new Vector2(moveHorizontal, 0);
            if (ghostBody.velocity.magnitude < maxSpeed)
                ghostBody.AddForce(movementHor * speed);
        }

        // Stops Mario when key is lifted
        //if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
                //ghostBody.velocity = Vector2.zero;

        // Limit Mario's Vertical Max Speed
        if (Mathf.Abs(moveVertical) > 0)
        {
            Vector2 movementVer = new Vector2(0, moveVertical);
            if (ghostBody.velocity.magnitude < maxSpeed)
                ghostBody.AddForce(movementVer * speed);
        }

        // Stops Mario when key is lifted
        //if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
                //ghostBody.velocity = Vector2.zero;
    }
}
