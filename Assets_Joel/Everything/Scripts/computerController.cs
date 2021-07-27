using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerController : MonoBehaviour
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
    GameObject gear;
    Rigidbody2D gearBody;
    SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        gear = GetChildWithName("Gear");
        gearBody = gear.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("basketball")) {
            m_SpriteRenderer.sprite = newSprite;
            gear.SetActive(true);
            gear.transform.localPosition = new Vector3(0, -1, 0);
 
            

        }
    }
}
