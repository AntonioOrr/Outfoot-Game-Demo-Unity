using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanStepInput : MonoBehaviour
{
    [SerializeField]
    private InputField input;

    int number;
    public static int stepTotal;
    public static int mySteps;

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }
    public void GetInput(string steps)
    {
        if (int.TryParse(input.text, out number))
        {
            if (number > 0)
            {
                stepTotal += number;
                mySteps = number;
                EnergySaved.addToEnergy = true;
            }

        }
        input.text = "";
    }
    public void myFunction()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        if (int.TryParse(input.text, out number))
        {
            if (number > 0)
            {
                stepTotal += number;
                mySteps = number;
                EnergySaved.addToEnergy = true;
            }

        }
        input.text = "";
    }
}
