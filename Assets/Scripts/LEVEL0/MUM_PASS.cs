using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MUM_PASS : MonoBehaviour
{
    public Rigidbody2D targetBody;
    private Transform passTransform;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        passTransform = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector2.Distance(targetBody.transform.position, passTransform.position);
        Debug.Log(dist);
        if (dist < 0.2f)
        {
            Debug.Log("Level Pass - moving to next scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
