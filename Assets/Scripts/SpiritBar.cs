using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpiritBar : MonoBehaviour
{
    //GameConstants
    public GameConstants gameConstants;
    // Get Spirit Bar Image
    private Image barImage;
    //Get Spirit Object
    private Spirit spirit;
    //Determine whether to decrease Spirit
    bool decreaseSpirit = false;

    public UnityEvent onDeath;

    private AudioSource detectAudio;

    private void Awake()
    {
        spirit = new Spirit(gameConstants);

        barImage = transform.Find("Spirit").GetComponent<Image>();
    }

    private void Start() {
        detectAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (decreaseSpirit)
        {
            spirit.Update();
            barImage.fillAmount = spirit.GetSpiritNormalised();
            detectAudio.PlayOneShot(detectAudio.clip);
        }

        if (barImage.fillAmount == 0)
        {
            onDeath.Invoke();
        }

    }

    public void enableDecreaseSpirit()
    {
        decreaseSpirit = true;
      
    }

    public void disableDecreaseSpirit()
    {
        decreaseSpirit = false;
    }

    public class Spirit
    {

        // Spirit Values
        private int Max_Spirit;
        private float currentPlayerSpirit;
        private float spirit_DecreaseRate;


        public Spirit(GameConstants gameConstants)
        {
            Max_Spirit = gameConstants.Max_Spirit;
            currentPlayerSpirit = gameConstants.currentPlayerSpirit;
            spirit_DecreaseRate = gameConstants.spirit_DecreaseRate;
        }

        public void Update()
        {
            if (currentPlayerSpirit != 0)
                currentPlayerSpirit -= spirit_DecreaseRate * Time.deltaTime;
        }

        public float GetSpiritNormalised()
        {

            return currentPlayerSpirit / Max_Spirit;
        }
    }
}




