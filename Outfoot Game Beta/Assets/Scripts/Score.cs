using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    int highScore;
    Text scoreText;

    //references
    public Text panelScore;
    public Text panelHighScore;
    public GameObject newImg;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        panelScore.text = score.ToString();
        scoreText.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void Scored()
    {
        if (GameManager.gameHasStarted == true)
        {
            score++;
            scoreText.text = score.ToString();
            //panelScore.text = score.ToString();

            if(score > highScore)
            {
                highScore = score;
                panelHighScore.text = highScore.ToString();
                PlayerPrefs.SetInt("highscore", highScore);
                newImg.SetActive(true);
            }
        }
    }

    public void DefeatedEnemy()
    {
        score = score + 10;
        scoreText.text = score.ToString();
    }

    public void DefeatedBird()
    {
        score = score + 5;
        scoreText.text = score.ToString();
    }

    public void DefeatedBoss()
    {
        score = score + 100;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
