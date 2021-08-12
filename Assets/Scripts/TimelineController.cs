using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public bool questComplete = false;

    public void Play() {
        playableDirector.Play();
        
        }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (questComplete) {

            Play();
            questComplete = false;
        
        }
    }
}
