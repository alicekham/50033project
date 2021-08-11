using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
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
    public GameObject Line3Battery;

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

                Line2Battery.SetActive(false);
                Line3Battery.SetActive(true);
                Line1Ghost.SetActive(false);
                Bark.PlayOneShot(barkSound);
                if (Line2GhostGear.activeSelf == true) Line2GhostGear.SetActive(false);
                Line2GhostBattery.SetActive(true);

                if (Line2Gear.activeSelf == false) Line2Info.SetActive(false);
            }
        }
    }
}
