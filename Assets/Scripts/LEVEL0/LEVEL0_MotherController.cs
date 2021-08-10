using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LEVEL0_MotherController : MonoBehaviour
{
    private Rigidbody2D motherBody;
    private Animator motherAnimator;
    private NavMeshAgent motherAgent;
    private Vector3 dir;
    private bool walkState;

    // Start is called before the first frame update
    void Start()
    {
        motherBody = GetComponent<Rigidbody2D>();
        motherAnimator = GetComponent<Animator>();

        motherAgent = GetComponent<NavMeshAgent>();
        motherAgent.updateRotation = false;
        motherAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(dir.x) > 0 || Mathf.Abs(dir.y) > 0)
        {
            motherAnimator.SetFloat("Horizontal", dir.x);
            motherAnimator.SetFloat("Vertical", dir.y);

            if (!walkState) {
                walkState = true;
                motherAnimator.SetBool("walkState", walkState);
            }
        } else
        {
            if (walkState) {
                walkState = false;
                motherAnimator.SetBool("walkState", walkState);
                motherBody.velocity = Vector3.zero;
            }
        }
    }
}
