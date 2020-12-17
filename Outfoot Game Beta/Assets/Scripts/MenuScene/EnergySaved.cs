using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySaved : MonoBehaviour
{
    public int energy;
    Text energyText;
    public static int savedEn;
    public static bool addToEnergy;
    // Start is called before the first frame update
    void Start()
    {
        energy = PlayerPrefs.GetInt("Energy");
        if (energy != Energy.energy && Energy.energy != 0)
        {
            energy = Energy.energy;
            PlayerPrefs.SetInt("Energy", energy);
        }
        else if (Energy.sceneTransition)
        {
            energy = PlayerPrefs.GetInt("Energy");
            
        }  
        else if (!Energy.sceneTransition)
            PlayerPrefs.SetInt("Energy", energy);
        
        energyText = GetComponent<Text>();
        energyText.text = energy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (addToEnergy == true)
        {
            energy += ScanStepInput.mySteps;
            ScanStepInput.mySteps = 0;
            PlayerPrefs.SetInt("Energy", energy);
            energyText = GetComponent<Text>();
            energyText.text = energy.ToString();
            addToEnergy = false;
        }
        if (energy > 0)
            MenuManager.animate = true;
        else
        {
            MenuManager.animate = false;
        }
        if (energy >= 999)
        {
            energy = 999;
            PlayerPrefs.SetInt("Energy", energy);
            energyText = GetComponent<Text>();
            energyText.text = energy.ToString();
        }
    }
}
