using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T4_Pass : MonoBehaviour
{
    public Transform targetTransform;
    public Transform sisterTransform;
    private Transform passTransform;
    private float distFromItem;
    private float distFromsister;

    void Start()
    {
        passTransform = GetComponent<Transform>();
    }

    void Update()
    {
        distFromItem = Vector2.Distance(targetTransform.position, passTransform.position);
        distFromsister = Vector2.Distance(sisterTransform.position, passTransform.position);

        if(distFromItem < 0.5f && distFromsister > 0.5f)
        {
            Debug.Log("Tutorial 4 Pass!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
