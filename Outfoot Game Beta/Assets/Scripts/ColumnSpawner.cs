using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;

    public float maxTime;
    float timer;

    public float maxY;
    public float minY;
    float randY;
    float temp;
    //Pipes will respawn on phase 2, after enemy phase (phase 1). Duration time for phase 2 is on field below
    int pipeRespawns;
    int pipesPassed;

    // Start is called before the first frame update
    void Start()
    {
        //InstantiateColumn();
        //column.SetActive(false);
        pipeRespawns = 5;
        temp = maxTime;
        pipesPassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pipesPassed >= pipeRespawns)
        {
            GameManager.startPhase2 = false;
            GameManager.startPhase3 = true;
            temp = maxTime;
            maxTime = 8;
            pipeRespawns += 5;
            pipesPassed = 0;
        }
        
        if (GameManager.gameOver == false && GameManager.gameHasStarted == true && GameManager.startPhase2 == true)
        {
            maxTime = temp;
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                //column.SetActive(true);
                InstantiateColumn();
                timer = 0;
                pipesPassed++;
            }
        }

    }

    public void InstantiateColumn()
    {
        randY = Random.Range(minY, maxY);
        GameObject newColumn = Instantiate(column);
        newColumn.transform.position = new Vector2(
            transform.position.x, randY);
    }
}
