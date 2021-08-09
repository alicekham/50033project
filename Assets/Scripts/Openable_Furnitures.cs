using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Openable_Furnitures : MonoBehaviour
{
    [SerializeField] GameObject[] specs;
    [SerializeField] SpriteRenderer[] sprites;
    [SerializeField] Sprite[] newSprites;
    [SerializeField] Rigidbody2D[] openBodies;
    private float distFromMum;
    public Rigidbody2D mumBody;
    Vector2 velocity;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<openBodies.Length;i++)
        {
            distFromMum = Vector2.Distance(mumBody.transform.position, openBodies[i].transform.position);
            velocity = openBodies[i].transform.position - mumBody.transform.position;
            dir = velocity.normalized;
            // Debug.Log(openBodies[i].name + ": " + dir);
            if (i==5)
            {
                Debug.Log("distFromMum: " + distFromMum);
            }
            if(Input.GetKeyDown("m") && distFromMum < 1.0f)
            {
                // open the furniture --> change sprite of furniture
                sprites[i].sprite = newSprites[i];

                // activate the glasses
                specs[i].SetActive(true);
            }
        }
    }
}
