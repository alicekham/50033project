using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeath : MonoBehaviour
{
    public AudioSource deathAudioSource;
    private AudioClip deathSound;
    private float groundValue;

    public GameObject deadGhost;

    public GameObject UILayer;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = deathAudioSource.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayerDiesSequence()
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
        //Time.timeScale = 0;
        StartCoroutine(flatten());
    }

    IEnumerator flatten()
    {
        Debug.Log("Flatten starts");
        deathAudioSource.PlayOneShot(deathSound);
        int steps = 10;
        float stepper = 1.0f / (float)steps;

        for (int i = 0; i < steps; i++)
        {
            if (deadGhost.transform.localScale.y > 0f)
            {
                deadGhost.transform.localScale = new Vector3(deadGhost.transform.localScale.x, deadGhost.transform.localScale.y - stepper, deadGhost.transform.localScale.z);
            }
            // make sure enemy is still above ground
            deadGhost.transform.position = new Vector3(deadGhost.transform.position.x, deadGhost.transform.position.y - 5, deadGhost.transform.position.z);
            yield return null;
        }
        deadGhost.gameObject.SetActive(false);
        yield break;
    }
}