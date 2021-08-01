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

    public GameObject basketball;
    private float distWithBall;


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
        distWithBall = Vector2.Distance(gearBody.transform.position, basketball.transform.position);
        if (distWithBall <= 0.3) {
            m_SpriteRenderer.sprite = newSprite;
            gear.SetActive(true);
            gear.transform.localPosition += new Vector3(0, -5f, 0);
        }
    }
}
