using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsController : MonoBehaviour
{

    public GameObject DoorA;
    public GameObject DoorB;
    

    GameObject GetChildWithName(string name) {
        Transform trans = this.gameObject.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) {
            return childTrans.gameObject;
        } else {
            return null;
        }
    }
    public doorHorizontal csA;
    public doorVertical csB;

    // Start is called before the first frame update
    void Start()
    {
    DoorA = GetChildWithName("DoorA"); 
    DoorB = GetChildWithName("DoorB"); 
    doorHorizontal csA = DoorA.GetComponent<doorHorizontal>();
    doorVertical csB = DoorB.GetComponent<doorVertical>();
    }

void doorReset() {
    Debug.Log("Reset Happening");
    if (csA == null && csB == null) {
        DoorA.SetActive(true);
        DoorB.SetActive(true);
        }
    }
 
}
