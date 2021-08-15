using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Guide : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;

    public void OK()
    {
        Canvas1.SetActive(false);
        Canvas2.SetActive(true);

    }
    public void SkipStory()
    {
        Debug.Log("Skip Story");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
