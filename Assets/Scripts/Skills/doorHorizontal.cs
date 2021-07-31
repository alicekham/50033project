using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHorizontal : MonoBehaviour
{
    
    Collider2D doorCollider;
    Animator doorAnimator;
    private AudioSource openSound;
    // Start is called before the first frame update
    void Start()
    {
    doorCollider = GetComponent<Collider2D>();
    doorAnimator = GetComponent<Animator>();
    openSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col) {
   
          if (col.gameObject.CompareTag("mother")) {
              Debug.Log("Opening Door?");
              if (Input.GetKeyDown("space")) {
                     doorAnimator.SetTrigger("Open");
                     openSound.PlayOneShot(openSound.clip);
                     doorCollider.enabled = false;
                     



              }}

          }
      


}