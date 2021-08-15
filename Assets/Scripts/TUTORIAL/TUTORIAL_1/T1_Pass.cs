using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T1_Pass : MonoBehaviour
{
    public Transform targetTransform;
    private Transform passTransform;
    private float dist;
    public Animator transition;

    void Start()
    {
        passTransform = GetComponent<Transform>();
    }

    void Update()
    {
        dist = Vector2.Distance(targetTransform.position, passTransform.position);
        if(dist < 0.5f)
        {
            Debug.Log("Tutorial 1 Pass!");
            StartCoroutine(Loadlevel());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Loadlevel() {
        //play animation
        transition.SetTrigger("Start");

        //wait time
        yield return new WaitForSeconds(1.0f);


    }
}
