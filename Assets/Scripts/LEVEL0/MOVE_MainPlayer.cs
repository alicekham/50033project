using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MOVE_MainPlayer : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    private Rigidbody2D ghostBody;
    private NavMeshAgent ghostAgent;
    // Start is called before the first frame update
    void Start()
    {
        ghostBody = GetComponent<Rigidbody2D>();
        ghostBody.isKinematic = true;

        ghostAgent = GetComponent<NavMeshAgent>();
        ghostAgent.updateRotation = false;
        ghostAgent.updateUpAxis = false;
    }

    // Movement
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        ghostBody.MovePosition(ghostBody.position + (movement * speed * Time.fixedDeltaTime));
    }
}