using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSuccess : MonoBehaviour
{
    public AudioSource successAudioSource;
    private AudioClip successSound;

    public GameObject UILayer;

    public GameObject QuestObj1;
    public GameObject QuestObj2;
    public GameObject QuestObj3;

    public GameConstants gameConstants;

    // Start is called before the first frame update
    void Start()
    {
        successSound = successAudioSource.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestObj1.activeSelf & QuestObj2.activeSelf & QuestObj3.activeSelf)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            foreach (Transform child in UILayer.transform)
            {
                if (child != this.transform)
                {
                    child.gameObject.SetActive(false);
                }

            }
        }
    }
}
