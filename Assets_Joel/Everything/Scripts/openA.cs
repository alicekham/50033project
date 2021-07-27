using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openA : MonoBehaviour
{
    GameObject GetChildWithName(string name) {
     Transform trans = this.gameObject.transform;
     Transform childTrans = trans.Find(name);
     if (childTrans != null) {
         return childTrans.gameObject;
     } else {
         return null;
     }
    }
    GameObject specs;
    Rigidbody2D specsBody;
    SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;
    Collider2D doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        specs = GetChildWithName("specsA");
        specsBody = specs.GetComponent<Rigidbody2D>();
        doorCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionStay2D(Collision2D col) {
   
          if (col.gameObject.CompareTag("mother")) {
              Debug.Log("getting specs?");
              if (Input.GetKeyDown("space")) {
                     m_SpriteRenderer.sprite = newSprite;
                     specs.SetActive(true);
                     specs.transform.localPosition = new Vector3(0, -1, 0);
                     doorCollider.enabled = false;

              }}

          }
}
