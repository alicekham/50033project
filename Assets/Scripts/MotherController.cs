using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D motherBody;
    private Animator motherAnimator;
    private Vector3 dir;
    private Vector3 posn;
    private Vector3 newposn;
    private bool walkState;

    // Start is called before the first frame update
    void Start()
    {
        motherBody = GetComponent<Rigidbody2D>();
        motherAnimator = GetComponent<Animator>();
        posn = motherBody.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        newposn = motherBody.transform.localPosition;
        dir = newposn - posn;
        posn = newposn;
        // Debug.Log(dir);
        fieldOfView.SetDirection(dir);
        fieldOfView.SetOrigin(transform.position);
    
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
