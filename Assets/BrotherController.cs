using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class BrotherController : MonoBehaviour
{
    public Rigidbody2D ghostBody;
    private float distWithGhost;
    private int counter = 0;
    private bool metBrother = false;

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line1;
    public GameObject Line2Info;
    public GameObject Line2Gear;
    public GameObject Line2Battery;
    
    public GameObject Line1Ghost;
    //public GameObject Line3Ghost;

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
                metBrother = true;

                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(true);
                GhostChatQuest3.SetActive(false);

                Line1.SetActive(false);
                Line2Gear.SetActive(true);
                Line2Battery.SetActive(true);
                Line2Info.SetActive(true);
                Bark.PlayOneShot(barkSound);
                Line1Ghost.SetActive(true);
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
        if (metBrother == true) counter++;
    }
}
