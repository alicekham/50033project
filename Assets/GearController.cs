using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    private int counter = 0;

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line1Ghost;
    public GameObject Line2Gear;
    public GameObject Line2Battery;
    public GameObject Line2Info;
    public GameObject Line2GhostGear;
    public GameObject Line2GhostBattery;
    public GameObject Line3Gear;

    // Start is called before the first frame update
    void Start()
    {
        barkSound = Bark.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            counter++;
            if (counter == 1)
            {
                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(true);
                GhostChatQuest3.SetActive(false);

                Line2Gear.SetActive(false);
                Line3Gear.SetActive(true);
                Line1Ghost.SetActive(false);
                Bark.PlayOneShot(barkSound);
                if (Line2GhostBattery.activeSelf == true) Line2GhostBattery.SetActive(false);
                Line2GhostGear.SetActive(true);

                if (Line2Battery.activeSelf == false) Line2Info.SetActive(false);
            }
        }
    }
}
