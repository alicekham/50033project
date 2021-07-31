using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioSource mainmusicAudio;
    // Start is called before the first frame update
    void Start()
    {
        mainmusicAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
