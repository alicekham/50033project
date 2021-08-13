using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockController : MonoBehaviour
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
    GameObject battery;
    Rigidbody2D batteryBody;
    SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;

    public GameObject basketball;
    private float distWithBall;

    public bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        battery = GetChildWithName("Battery");
        batteryBody = battery.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distWithBall = Vector2.Distance(this.transform.position, basketball.transform.position);
        if (distWithBall <= 0.3)
        {
            m_SpriteRenderer.sprite = newSprite;
            isBroken = true;
            battery.SetActive(true);
            battery.transform.localPosition += new Vector3(0, -2, 0);
        }
    }
}
