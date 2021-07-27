using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    //GameConstants
    public GameConstants gameConstants;
    // Get Energy Bar Image
    private Image barImage;
    //Get Energy Object
    private Energy energy;
    //Determine whether to decrease Energy
    bool decreaseEnergy = false;

    private void Awake()
    {
        energy = new Energy(gameConstants);

        barImage = transform.Find("Energy").GetComponent<Image>();
    }

    private void Update()
    {
        if (decreaseEnergy)
        {
            energy.Update();
            barImage.fillAmount = energy.GetEnergyNormalised();
        }
        
    }

    public void enableDecreaseEnergy()
    {
        decreaseEnergy = true;
    }

    public void disableDecreaseEnergy()
    {
        decreaseEnergy = false;
    }

    public class Energy
    {

        // Spirit Values
        private int Max_Energy;
        private float currentPlayerEnergy;
        private float energy_DecreaseRate;

        public Energy(GameConstants gameConstants)
        {
            Max_Energy = gameConstants.Max_Energy;
            currentPlayerEnergy = gameConstants.currentPlayerEnergy;
            energy_DecreaseRate = gameConstants.energy_DecreaseRate;
            Debug.Log(Max_Energy);
            Debug.Log(currentPlayerEnergy);
            Debug.Log(energy_DecreaseRate);
        }

        public void Update()
        {
            if (currentPlayerEnergy != 0)
                currentPlayerEnergy -= (energy_DecreaseRate * Time.deltaTime);
        }

        public float GetEnergyNormalised()
        {
            return currentPlayerEnergy / Max_Energy;
        }
    }
}
