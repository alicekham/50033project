using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObject_2 : MonoBehaviour
{
    public Text pickUpText;
    private bool pickUpAllowed;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown("v")) {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;

        }
    }

    private void PickUp() {
        Destroy(gameObject);
    }
}
