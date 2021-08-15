using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyCarLightController : MonoBehaviour
{
    public Rigidbody2D ghostBody;
    private float distWithGhost;

    public GameObject questLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distWithGhost = Vector2.Distance(this.transform.position, ghostBody.transform.position);
        if (distWithGhost < 2.5f)
        {
            questLight.SetActive(true);
        }
        else {
            questLight.SetActive(false);
        }
    }
}
