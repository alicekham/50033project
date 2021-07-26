using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorVertical : MonoBehaviour
{
    
    Collider2D doorCollider;
    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
    doorCollider = GetComponent<Collider2D>();
    doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D col) {
   
          if (col.gameObject.CompareTag("mother")) {
              Debug.Log("Opening Door?");
              if (Input.GetKeyDown("space")) {
                     doorAnimator.SetTrigger("Open");
                     doorCollider.enabled = false;
                     



              }}

          }
      


}