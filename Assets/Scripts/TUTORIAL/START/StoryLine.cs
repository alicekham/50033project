using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryLine : MonoBehaviour
{
    public void SkipStory()
    {
        Debug.Log("Skip Story");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
