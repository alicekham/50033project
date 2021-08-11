using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Openable_Furnitures : MonoBehaviour
{
    [SerializeField] GameObject[] specs;
    [SerializeField] SpriteRenderer[] sprites;
    [SerializeField] Sprite[] newSprites;
    [SerializeField] Rigidbody2D[] openBodies;
    private float distFromMum;
    public Rigidbody2D mumBody;
    Vector2 velocity;
    Vector2 dir;
    
    private int[] counterList = {0, 0, 0, 0, 0};

    public AudioSource Bark;
    private AudioClip barkSound;

    //Texts to update
    public GameObject GhostChatQuest1;
    public GameObject GhostChatQuest2;
    public GameObject GhostChatQuest3;

    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;
    public GameObject Line1Ghost;
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
        for (int i=0; i<openBodies.Length;i++)
        {
            distFromMum = Vector2.Distance(mumBody.transform.position, openBodies[i].transform.position);
            velocity = openBodies[i].transform.position - mumBody.transform.position;
            dir = velocity.normalized;
            // Debug.Log(openBodies[i].name + ": " + dir);
            if (i==5)
            {
                Debug.Log("distFromMum: " + distFromMum);
            }
            if(Input.GetKeyDown(KeyCode.Return) && distFromMum < 1.3f)
            {
                // open the furniture --> change sprite of furniture
                sprites[i].sprite = newSprites[i];

                // activate the glasses
                specs[i].SetActive(true);
            }

            if (specs[0].activeSelf == true)
            {
                counterList[0]++;
                Debug.Log(counterList);
                if (counterList[0] == 1)
                {
                    GhostChatQuest1.SetActive(false);
                    GhostChatQuest2.SetActive(false);
                    GhostChatQuest3.SetActive(true);

                    if (Line1Ghost.activeSelf == true) Line1Ghost.SetActive(false);
                    if (Line2Ghost.activeSelf == true) Line2Ghost.SetActive(false);
                    Bark.PlayOneShot(barkSound);
                    Line2.SetActive(false);
                    Line3.SetActive(true);
                    Line3Ghost.SetActive(true);
                }
            }
            else if (i < 5 & specs[i].activeSelf == true)
            {
                counterList[i]++;
                if (counterList[i] == 1)
                {
                    GhostChatQuest1.SetActive(false);
                    GhostChatQuest2.SetActive(false);
                    GhostChatQuest3.SetActive(true);

                    if (Line1.activeSelf == true) Line1.SetActive(false);
                    if (Line1Ghost.activeSelf == true) Line1Ghost.SetActive(false);
                    Bark.PlayOneShot(barkSound);
                    Line2Ghost.SetActive(true);
                }
                
            }
        }
    }
}
