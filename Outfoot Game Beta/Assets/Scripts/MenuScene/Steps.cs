using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steps : MonoBehaviour
{
    int step;
    Text stepText;
    // Start is called before the first frame update
    void Start()
    {
        step = PlayerPrefs.GetInt("Steps");
        ScanStepInput.stepTotal = step;
        if (Energy.sceneTransition)
            ScanStepInput.stepTotal = PlayerPrefs.GetInt("Steps");
        

        stepText = GetComponent<Text>();
        stepText.text = step.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScanStepInput.stepTotal != 0)
        {
            step = ScanStepInput.stepTotal;
            PlayerPrefs.SetInt("Steps", ScanStepInput.stepTotal);
        }
        stepText = GetComponent<Text>();
        stepText.text = step.ToString();
    }
}
