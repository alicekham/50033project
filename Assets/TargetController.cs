using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;

    public GameObject basketball;
    private float distWithBall;

    public bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distWithBall = Vector2.Distance(this.transform.position, basketball.transform.position);
        if (distWithBall <= 0.3)
        {
            m_SpriteRenderer.sprite = newSprite;
            isBroken = true;
        }
    }
}
