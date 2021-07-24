using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D motherBody;
    private Vector3 dir;
    private Vector3 posn;
    private Vector3 newposn;

    // Start is called before the first frame update
    void Start()
    {
        motherBody = GetComponent<Rigidbody2D>();
        posn = motherBody.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        newposn = motherBody.transform.localPosition;
        dir = newposn - posn;
        posn = newposn;
        Debug.Log(dir);
        fieldOfView.SetDirection(dir);
        fieldOfView.SetOrigin(transform.position);
    }
}
