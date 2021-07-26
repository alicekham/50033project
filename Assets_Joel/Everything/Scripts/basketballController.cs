using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketballController : MonoBehaviour
{   
    public Rigidbody2D basketballBody;

    // Start is called before the first frame update
    void Start()
    {
      basketballBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
