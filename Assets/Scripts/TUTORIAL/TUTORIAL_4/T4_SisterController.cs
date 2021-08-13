using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private NavMeshAgent sisterAgent;

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
    sisterAgent = GetComponent<NavMeshAgent>();
    sisterAgent.updateRotation = false;
    sisterAgent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {   //Update FOV
        newposn = daughterBody.transform.localPosition;
        dir = newposn - posn;
        posn = newposn;

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
    }
}