using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTLER_PASS : MonoBehaviour
{
    public Transform targetTransform;
    public Transform butlerTransform;
    private Transform passTransform;
    private float dist1;
    private float dist2;
    // Start is called before the first frame update
    void Start()
    {
        passTransform = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist1 = Vector2.Distance(targetTransform.position, passTransform.position);
        dist2 = Vector2.Distance(butlerTransform.position, passTransform.position);
        
        if (dist1 < 0.4f && dist2 > 0.5f)
        {
            Debug.Log("Level Pass - moving to next scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
