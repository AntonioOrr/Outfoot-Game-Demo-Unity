using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    Image img;

    //references
    public Sprite playSprite;
    public Sprite pausedSprite;

    public void Start()
    {
        img = GetComponent<Image>();
    }
    public void OnPausedGame()
    {
        if (GameManager.gamePaused == false)
        {
            Time.timeScale = 0;
            img.sprite = playSprite;
            GameManager.gamePaused = true;
            //bulletFire.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            img.sprite = pausedSprite;
            GameManager.gamePaused = false;
            //bulletFire.SetActive(true);
        }
    }
}
