using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T3_Pass : MonoBehaviour
{
    public Transform targetTransform;
    public Transform butlerTransform;
    private Transform passTransform;
    private float distFromItem;
    private float distFromButler;

    void Start()
    {
        passTransform = GetComponent<Transform>();
    }

    void Update()
    {
        distFromItem = Vector2.Distance(targetTransform.position, passTransform.position);
        distFromButler = Vector2.Distance(butlerTransform.position, passTransform.position);

        if(distFromItem < 0.5f && distFromButler > 0.5f)
        {
            Debug.Log("Tutorial 3 Pass!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
