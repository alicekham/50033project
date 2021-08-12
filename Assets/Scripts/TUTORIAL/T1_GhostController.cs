using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class T1_GhostController : MonoBehaviour
{
    // [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D ghostBody;
    private SpriteRenderer ghostSprite;
    public float speed;
    public float maxSpeed = 40f;
    private Vector2 movement;
    private NavMeshAgent ghostAgent;

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

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        ghostBody.MovePosition(ghostBody.position + (movement * speed * Time.fixedDeltaTime));
    }
}
