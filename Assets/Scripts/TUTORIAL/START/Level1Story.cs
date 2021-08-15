using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Story : MonoBehaviour
{
    public GameObject Canvas;

    public void ContinueStory()
    {
        Canvas.SetActive(true);

    }
    public void SkipStory()
    {
        Debug.Log("Skip Story");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
