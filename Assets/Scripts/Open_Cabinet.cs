using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Open_Cabinet : MonoBehaviour
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
    private Rigidbody2D fridgeBody;
    public Sprite newSprite;
    private NavMeshObstacle fridgeObstacle;
    private float distFromMum;
    public Rigidbody2D mumBody;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        fridgeBody = GetComponent<Rigidbody2D>();
        specs = GetChildWithName("BlackSpecs");
        specsBody = specs.GetComponent<Rigidbody2D>();
        // fridgeObstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        distFromMum = Vector2.Distance(mumBody.transform.position, fridgeBody.transform.position);
        Debug.Log("distFromMum: " + distFromMum);
        if(Input.GetKeyDown("m") && distFromMum < 1.5f)
        {
            Debug.Log("mum is trying to open the door!");
            // fridgeObstacle.carving = false;
            m_SpriteRenderer.sprite = newSprite;
            specs.SetActive(true);
            // specs.transform.localPosition = new Vector3(0, -1, 0);
        }
    }
}
