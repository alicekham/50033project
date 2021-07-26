using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("targetPos : " + targetPos);
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        // transform.position = new Vector3(target.x, targetPos.y, transform.position.z);
    }
}
