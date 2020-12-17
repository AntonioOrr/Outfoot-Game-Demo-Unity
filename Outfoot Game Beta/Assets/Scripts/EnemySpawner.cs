using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject bird;
    

    public float maxTime;
    float timer;
    public float birdFlockTime;
    float timer0;

    float randA;
    float randB;
    float randY;
    float temp = 3;

    public static bool bossSpawned;
    Rigidbody2D bossRend;

    Player target;
    int eR;
    int eP;
    //bool initial;
    //int enemyRespawns;
    //int enemiesPassed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player>();
        bossSpawned = false;
        eR = 10;
        eP = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eP >= eR)
        {
            GameManager.startPhase1 = false;
            eR += 5;
            GameManager.startPhase3 = true;
            eP = 0;
            temp = 3;
            if (bossSpawned == false)
            {
                InstantiateEnemy4();
                bossSpawned = true;
            }
            
        }

        if (GameManager.gameOver == false && GameManager.gameHasStarted == true && GameManager.startPhase1 == true )
        {
            timer += Time.deltaTime;
            timer0 += Time.deltaTime;
            
            if (timer >= temp)
            {
                if (timer0 >= birdFlockTime)
                {
                    InstantiateBird();
                    timer0 = 0;
                    birdFlockTime -= 0.01f;
                    if (birdFlockTime < 1)
                        birdFlockTime = 1;
                }
                randA = Random.Range(0f, 1f);
               
                temp = maxTime;
                //column.SetActive(true);
                if (randA < 0.33f || bossSpawned == true)
                {
                    InstantiateEnemy1();
                }
                else if (randA >= 0.33f && randA <= 0.66f)
                {
                    InstantiateEnemy2();
                }
                else
                {
                    InstantiateEnemy3(target);
                }
                
                timer = 0;
                eP++;
            }
        }
        /* else if (GameManager.gameOver == false && GameManager.gameHasStarted == true && GameManager.startPhase3 == true)
        {
           
            if (bossSpawned == false)
                temp = 6.5f;
            timer += Time.deltaTime;
            if (timer >= temp)
            {
                if (bossSpawned == false)
                {
                    InstantiateEnemy4();
                    bossSpawned = true;
                }
                Debug.Log("Phase 3");
                temp = maxTime + Time.deltaTime;
                InstantiateEnemy1();
                timer = 0;
            }
        }
        else
        {
            //bossSpawned = false;
        }*/
    }

    public void InstantiateBird()
    {
        randY = Random.Range(-0.3f, 1f);
        GameObject newBird = Instantiate(bird);
        newBird.transform.position = new Vector2(
            transform.position.x, randY);
    }

    public void InstantiateEnemy1()
    {
        GameObject newEnemy = Instantiate(enemy1);
        newEnemy.transform.position = new Vector2(
            transform.position.x, transform.position.y);
    }

    public void InstantiateEnemy2()
    {
        GameObject newEnemy = Instantiate(enemy2);
        newEnemy.transform.position = new Vector2(
            transform.position.x, transform.position.y);
    }

    public void InstantiateEnemy3(Player target)
    {
        GameObject newEnemy = Instantiate(enemy3);
        newEnemy.transform.position = new Vector2(
            transform.position.x, target.transform.position.y);
    }

    public void InstantiateEnemy4()
    {
        GameObject newEnemy = Instantiate(enemy4);
        newEnemy.transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y + 0.9f);
    }

    int getR()
    {
        return eR;
    }

    int getP()
    {
        return eP;
    }
}
