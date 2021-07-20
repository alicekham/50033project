using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    // [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D ghostBody;
    private SpriteRenderer ghostSprite;
    public float speed;
    public float maxSpeed = 40f;
    private Vector2 movement;
    private NavMeshAgent ghostAgent;

    //private bool faceLeftState = false;
    //private bool faceRightState = false;
    //private bool faceUpState = false;
    //private bool faceDownState = true;
    // public float moveHorizontal;
    // public float moveVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set Framerate to 30 FPS
        Application.targetFrameRate = 30;
        ghostBody = GetComponent<Rigidbody2D>();
        ghostSprite = GetComponent<SpriteRenderer>();
        
        ghostAgent = GetComponent<NavMeshAgent>();
        ghostAgent.updateRotation = false;
        ghostAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        // ghostBody.MovePosition(ghostBody.position + (movement * speed * Time.fixedDeltaTime));
    }
}
