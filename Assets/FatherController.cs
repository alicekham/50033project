using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class FatherController : MonoBehaviour
{
    public Rigidbody2D ghostBody;
    private float distWithGhost;
    private int counter = 0;
    private bool metFather = false;

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line0;
    public GameObject Line1;
    public GameObject Line0Ghost;

    public TimelineControllerR taskReceivedAnim;


    // Start is called before the first frame update
    void Start()
    {
        barkSound = Bark.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        distWithGhost = Vector2.Distance(this.transform.position, ghostBody.transform.position);
        if (distWithGhost < 1)
        {
            counter++;
            if (counter == 1)
            {
                metFather = true;

                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(true);
                GhostChatQuest3.SetActive(false);

                Line0.SetActive(false);
                Line1.SetActive(true);
                Bark.PlayOneShot(barkSound);
                Line0Ghost.SetActive(true);
                taskReceivedAnim.questReceived = true;
            }

            //if (counter == 100)
            //{
            //GhostChatQuest1.SetActive(false);
            //GhostChatQuest2.SetActive(true);
            //GhostChatQuest3.SetActive(false);

            //Line2Ghost.SetActive(false);
            //Bark.PlayOneShot(barkSound);
            //Line3Ghost.SetActive(true);
            //}

        }
    }
}
