using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bookManager : MonoBehaviour
{
    public Rigidbody2D ghostBody;
    private float distWithGhost;
    private int counter2 = 0;

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line0;
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line0Ghost;
    public GameObject Line2Ghost;
    public GameObject Line3Ghost;


    // Start is called before the first frame update
    void Start()
    {
        barkSound = Bark.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        distWithGhost = Vector2.Distance(this.transform.position, ghostBody.transform.position);
        
        if (distWithGhost < 1.2)
        {
            counter2++;
            if (counter2 == 1)
            {
                GhostChatQuest1.SetActive(true);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(false);

                Line0.SetActive(false);
                Line1.SetActive(false);
                Line2.SetActive(true);
                Bark.PlayOneShot(barkSound);
                Line0Ghost.SetActive(false);
                Line2Ghost.SetActive(true);
            }

            if (counter2 == 80)
            {
                GhostChatQuest1.SetActive(true);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(false);

                Line2Ghost.SetActive(false);
                Bark.PlayOneShot(barkSound);
                Line3Ghost.SetActive(true);
            }

        } 
    }
}
