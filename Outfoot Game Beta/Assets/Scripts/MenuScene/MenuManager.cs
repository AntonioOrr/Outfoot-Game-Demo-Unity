using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject noPlayText;
    public static bool animate = false;

    public Animator blackFadeAnim;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnPlayBtnPressed()
    {
        //SceneManager.LoadScene("Game");
        blackFadeAnim.SetTrigger("fadeIn");
    }

    public void OnRateBtnPressed()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.OutfootCompany.OutfootGameBeta");
#endif 
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Energy") <= 0)
        {
            playBtn.SetActive(false);
            noPlayText.SetActive(true);
        }
        else
        {
            playBtn.SetActive(true);
            noPlayText.SetActive(false);
        }
    }
}
