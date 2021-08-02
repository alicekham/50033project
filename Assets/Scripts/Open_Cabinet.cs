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
    private Rigidbody2D cabinetBody;
    public Sprite newSprite;
    private NavMeshObstacle cabinetObstacle;
    private float distFromMum;
    public Rigidbody2D mumBody;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        specs = GetChildWithName("specsB");
        specsBody = specs.GetComponent<Rigidbody2D>();
        cabinetObstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        distFromMum = Vector2.Distance(mumBody.transform.position, cabinetBody.transform.position);
        Debug.Log("distFromMum: " + distFromMum);
        if(Input.GetKeyDown("m") && distFromMum < 1.5f)
        {
            Debug.Log("mum is trying to open the door!");
            cabinetObstacle.carving = false;
            m_SpriteRenderer.sprite = newSprite;
            specs.SetActive(true);
            specs.transform.localPosition = new Vector3(0, -1, 0);
        }
    }
}
