using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;

    public GameObject vaseObject;
    private float distWithVase;
    private bool holdVase = false;


    void Update()
    {
        distWithVase = Vector2.Distance(vaseObject.transform.position, grabDetect.transform.position);
        

        if (distWithVase <= 1f)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (holdVase) holdVase = false;
                else if (!holdVase) holdVase = true;

                if (holdVase & vaseObject.activeSelf == true)
                {
                    vaseObject.transform.parent = boxHolder;
                    vaseObject.transform.position = boxHolder.position;
                }
                else if (!holdVase)
                {
                    vaseObject.transform.parent = null;
                    //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }
    }
}
