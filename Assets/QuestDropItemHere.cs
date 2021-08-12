using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class QuestDropItemHere : MonoBehaviour
{
    public GameObject questItem;
    private float distWithQuestItem;

    public GameObject questMat;

    public AudioSource Bark;
    private AudioClip barkSound;
    private int Counter = 0;
    
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;
    
    public GameObject Line5Ghost;
    public GameObject LineEndGhost;
    public GameObject Line4;
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
        if (distWithQuestItem < 1.2f & questItem.transform.parent == null)
        {
            Counter++;
            if (Counter == 1)
            {
                GhostChatQuest1.SetActive(true);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(false);

                Line5Ghost.SetActive(false);
                LineEndGhost.SetActive(true);
                Bark.PlayOneShot(barkSound);
                Line4.SetActive(false);
                completedImg.SetActive(true);
                questItem.transform.position = questMat.transform.position;
                questItem.transform.parent = null;
                taskCompleteAnim.questComplete = true;
            }
        }
    }
}
