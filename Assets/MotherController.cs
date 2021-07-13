using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    private Rigidbody2D motherBody;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        motherBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = motherBody.velocity;
        fieldOfView.SetDirection(dir);
        fieldOfView.SetOrigin(transform.position);
    }
}
