using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //references
    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject scoreText;
    public GameObject OkButton;
    public GameObject getReady;
    public GameObject tapToStart;
    public GameObject pauseButton;
    public Animator blackFadeAnim;

    public static Vector2 bottomLeft;

    //game states
    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool startPhase1;
    public static bool startPhase2;
    public static bool startPhase3;
    public static bool gamePaused;
    public static bool standBy;

    public Text panelScore;

    public static int gameScore;
    int drawScore;


    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        Energy.noEnergy = false;
        gameOver = false;
        gameHasStarted = false;
        getReady.SetActive(true);
        tapToStart.SetActive(true);
        gamePaused = false;

    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        getReady.SetActive(false);
        tapToStart.SetActive(false);
        score.SetActive(true);
        scoreText.SetActive(true);
        pauseButton.SetActive(true);
        
        MovePrefab.prefabSpeed = 0.6f;
        startPhase1 = true;
        startPhase2 = false;
        startPhase3 = false;
    }

    public void GameOver()
    {
        gameOver = true;
        gameScore = score.GetComponent<Score>().GetScore();
        score.SetActive(false);
        scoreText.SetActive(false);
        Respawner.spawnsPassed = 0;
        Respawner.respawns = 5;
        Invoke("ActivateGameOverCanvas", 1);
        pauseButton.SetActive(false);
        if (Energy.noEnergy == true)
            OkButton.SetActive(false);
        else
            OkButton.SetActive(true);
        Energy.sceneTransition = true;
    }

    void ActivateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }

    public void OnOkButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    public void OnMenuBtnPressed()
    {
        //gameOverCanvas.SetActive(false);
        blackFadeAnim.SetTrigger("fadeIn");
        SceneManager.LoadScene("Menu");
        
    }

    public void DrawScore()
    {
        if(drawScore <= gameScore)
        {
            panelScore.text = drawScore.ToString();
            drawScore++;
            Invoke("DrawScore", 0.005f);
        }
    }

    public void phaseSwitch()
    {
        Debug.Log("Method");
        if (startPhase1 == true)
        {
            startPhase1 = false;
            startPhase2 = true;
        }
        else if (startPhase2 == true)
        {
            startPhase2 = false;
            startPhase3 = true;
        }
        else if (startPhase3 == true)
        {
            startPhase3 = false;
            startPhase1 = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
