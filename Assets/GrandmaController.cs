using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GrandmaController : MonoBehaviour
{
    public Rigidbody2D ghostBody;
    private float distWithGhost;
    private int counter = 0;

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line1Ghost;

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

        if (distWithGhost < 1.5f)
        {
            counter++;
            if (counter == 1)
            {
                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(true);

                Line1.SetActive(false);
                Line2.SetActive(true);
                Line1Ghost.SetActive(true);
                Bark.PlayOneShot(barkSound);
                taskReceivedAnim.questReceived = true;
            }
        }
    }
}
