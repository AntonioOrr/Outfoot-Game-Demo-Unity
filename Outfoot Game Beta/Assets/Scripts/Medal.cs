using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite normal;
    public Sprite bronze;
    public Sprite silver;
    public Sprite gold;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        int gameScore = GameManager.gameScore;

        if(gameScore < 100)
        {
            img.sprite = normal;
        }
        else if (gameScore >= 100 && gameScore < 200)
        {
            img.sprite = bronze;
        }
        else if (gameScore >= 200 && gameScore < 500)
        {
            img.sprite = silver;
        }
        else if (gameScore >= 500)
        {
            img.sprite = gold;
        }
    }
}
