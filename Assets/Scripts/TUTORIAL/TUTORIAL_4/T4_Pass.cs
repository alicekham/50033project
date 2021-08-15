using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T4_Pass : MonoBehaviour
{
    public TargetController clockBroken;
    public TargetController clockBroken2;
    public TargetController clockBroken3;
    private Transform passTransform;
    private float distFromItem;
    private float distFromsister;

    void Start()
    {
        passTransform = GetComponent<Transform>();
    }

    void Update()
    {
        //distFromItem = Vector2.Distance(targetTransform.position, passTransform.position);
        //distFromsister = Vector2.Distance(sisterTransform.position, passTransform.position);

        if(clockBroken.isBroken & clockBroken2.isBroken & clockBroken3.isBroken)
        {
            Debug.Log("Tutorial 4 Pass!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
