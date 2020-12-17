using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public static int energy;
    Text energyText;
    public static bool noEnergy = false;
    public static bool sceneTransition = false;
    //public float secondsToDrain;
    //float timerE;

    // Start is called before the first frame update
    void Start()
    {
        energy = PlayerPrefs.GetInt("Energy");
        energyText = GetComponent<Text>();
        energyText.text = energy.ToString();
    }

    public void energyLoss()
    {
        energy--;
        energyText.text = energy.ToString();
        EnergyStorage.energyUsed++;
    }

    public void setEnergy(int a)
    {
        energy = a;
    }

    public void energyStore()
    {

    }

    public void energyRunOut()
    {
        energyText.color = Color.red;
        noEnergy = true;
        PlayerPrefs.SetInt("Energy", 0);
    }

    public void energyStillHave()
    {
        noEnergy = false;
        energyText.color = Color.white;
        PlayerPrefs.SetInt("Energy", energy);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
        {
            energyRunOut();
        }
        else
        {
            energyStillHave();
        }
        /*timerE += Time.deltaTime;
        if (timerE >= secondsToDrain && GameManager.gameOver == false && GameManager.gameHasStarted == true)
        {
            energyLoss();
            timerE = 0;
            if (energy == 0)
            {
                energyText.color = Color.red;
                noEnergy = true;
            }
            else
            {
                noEnergy = false;
                energyText.color = Color.white;
            }
        }*/


    }
}
