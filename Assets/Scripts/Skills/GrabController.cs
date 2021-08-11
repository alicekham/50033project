using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public GameConstants gameConstants;
    public float rayDist = 2;

    public GameObject bookObject;
    private float distWithBook;
    private bool holdBook = false;

    public GameObject gearObject;
    private float distWithGear;
    private bool holdGear = false;

    public GameObject batteryObject;
    private float distWithBattery;
    private bool holdBattery = false;

    public GameObject glassesObject;
    private float distWithGlasses;
    private bool holdGlasses = false;

    //private int runOneTime = 0;

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        distWithBook = Vector2.Distance(bookObject.transform.position, grabDetect.transform.position);
        distWithGear = Vector2.Distance(gearObject.transform.position, grabDetect.transform.position);
        distWithGlasses = Vector2.Distance(glassesObject.transform.position, grabDetect.transform.position);
        distWithBattery = Vector2.Distance(batteryObject.transform.position, grabDetect.transform.position);


        if (distWithBook <= 1f & gameConstants.isButler)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (holdBook) holdBook = false;
                else if (!holdBook) holdBook = true;

                if (holdBook)
                {
                    bookObject.transform.parent = boxHolder;
                    bookObject.transform.position = boxHolder.position;
                }
                else if (!holdBook)
                {
                    bookObject.transform.parent = null;
                    //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }

        else if (distWithGear <= 1f & gameConstants.isButler)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (holdGear) holdGear = false;
                else if (!holdGear) holdGear = true;

                if (holdGear)
                {
                    gearObject.transform.parent = boxHolder;
                    gearObject.transform.position = boxHolder.position;
                }
                else if (!holdGear)
                {
                    gearObject.transform.parent = null;
                    //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }

        else if (distWithBattery <= 1f & gameConstants.isButler)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (holdBattery)
                {
                    holdBattery = false;
                    Debug.Log("dropping Battery");
                }
                else if (!holdBattery)
                {
                    holdBattery = true;
                    Debug.Log("holding Battery");
                }

                if (holdBattery)
                {
                    batteryObject.transform.parent = boxHolder;
                    batteryObject.transform.position = boxHolder.position;
                    //Debug.Log("Battery moving with me");
                }
                else if (!holdBattery)
                {
                    batteryObject.transform.parent = null;
                    //Debug.Log("Battery disowned");
                    //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }

            }
        }

        else if (distWithGlasses <= 1f & gameConstants.isButler)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (holdGlasses)
                {
                    holdGlasses = false;
                    Debug.Log("dropping Battery");
                }
                else if (!holdGlasses)
                {
                    holdGlasses = true;
                    Debug.Log("holding Battery");
                }

                if (holdGlasses)
                {
                    glassesObject.transform.parent = boxHolder;
                    glassesObject.transform.position = boxHolder.position;
                    //Debug.Log("Battery moving with me");
                }
                else if (!holdGlasses)
                {
                    glassesObject.transform.parent = null;
                    //Debug.Log("Battery disowned");
                    //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }

            }
        }
    }
}
