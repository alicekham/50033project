using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [SerializeField]  public GameObject[] lines;
    [SerializeField]  public Text[] lineText;
    private Text[] inumText;
    private int currentLine = 0;
    void Start()
    {
        lines[currentLine].SetActive(true);
    }
    
    public void Next()
    {
        Debug.Log("next");
        lines[currentLine].SetActive(false);
        currentLine += 1;
        if (currentLine == 4)
        {
            End();
        }
        lines[currentLine].SetActive(true);
        /*
        StopAllCoroutines();
        StartCoroutine(TypeSentence(lineText[currentLine].text));

        IEnumerator TypeSentence(string line)
        {
            inumText[currentLine].text = "";
            foreach(char letter in line.ToCharArray())
            {
                inumText[currentLine].text += letter;
                yield return null;
            }
        }
        */
    }

    void End()
    {
        Debug.Log("end");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    void Skip()
    {
        Debug.Log("skip");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
