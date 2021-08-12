using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class QuestDropItemHere2 : MonoBehaviour
{
    public GameObject questItem;
    public GameObject questItem2;
    private float distWithQuestItem;
    private float distWithQuestItem2;

    public GameObject questMat;

    private bool questGearComplete = false;
    private bool questBatteryComplete = false;

    public AudioSource Bark;
    private AudioClip barkSound;
    private int Counter = 0;
    private int Counter2 = 0;

    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line2Gear;
    public GameObject Line2Battery;
    public GameObject LineEndGhost;
    public GameObject Line3GearGetted;
    public GameObject Line3BatteryGetted;
    public GameObject completedImg;

    public TimelineController taskCompleteAnim;

    // Start is called before the first frame update
    void Start()
    {
        
        barkSound = Bark.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        distWithQuestItem = Vector2.Distance(this.transform.position, questItem.transform.position);
        distWithQuestItem2 = Vector2.Distance(this.transform.position, questItem2.transform.position);
        if (questGearComplete & questBatteryComplete)
        {
            Counter++;
            if (Counter == 1)
            {
                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(true);
                GhostChatQuest3.SetActive(false);

                if (Line2Gear.activeSelf == true) Line2Gear.SetActive(false);
                if (Line2Battery.activeSelf == true) Line2Gear.SetActive(false);
                LineEndGhost.SetActive(true);
                Line3GearGetted.SetActive(false);
                Bark.PlayOneShot(barkSound);
                completedImg.SetActive(true);
                taskCompleteAnim.questComplete = true;
            }
        }

        if (distWithQuestItem < 1.2f & questItem.transform.parent == null)
        {
            questGearComplete = true;
            Line3GearGetted.SetActive(false);
            questItem.transform.position = questMat.transform.position;
            questItem.transform.parent = null;
        }

        if (distWithQuestItem2 < 1.2f & questItem2.transform.parent == null)
        {
            questBatteryComplete = true;
            Line3BatteryGetted.SetActive(false);
            questItem2.transform.position = questMat.transform.position;
            questItem2.transform.parent = null;
        }

        
        
    }
}
