using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropItemHere3 : MonoBehaviour
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

    public GameObject Line3Ghost;
    public GameObject LineEndGhost;
    public GameObject Line3;
    public GameObject completedImg;

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
                GhostChatQuest1.SetActive(false);
                GhostChatQuest2.SetActive(false);
                GhostChatQuest3.SetActive(true);

                Line3Ghost.SetActive(false);
                LineEndGhost.SetActive(true);
                Bark.PlayOneShot(barkSound);
                Line3.SetActive(false);
                completedImg.SetActive(true);
                questItem.transform.position = questMat.transform.position;
                questItem.transform.parent = null;
            }
        }
    }
}
