using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //references
    public Score score;
    public float secondsToPoint;
    public Energy myEnergy;
    public float secondsToDrain;
    float timer;
    float timerE;
    public GameManager gameManager;
    public Sprite playerFlap;
    public Sprite playerDied;
    public Sprite playerTired;
    public ColumnSpawner columnSpawner;
    public GameObject groundObject;
    public static bool walkPastEnemy = false;
    public Animator hitEffect;

    SpriteRenderer sp;
    Animator anim;
    Rigidbody2D rb;
    float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > groundObject.transform.position.y + 0.5 && GameManager.gameOver == false)
        {
            anim.enabled = false;
            sp.sprite = playerFlap;
        }
        else if (gameObject.transform.position.y <= groundObject.transform.position.y + 0.5 && GameManager.gameOver == false)
        {
            anim.enabled = true;
        }
        if (Input.GetMouseButtonDown(0) && 
            GameManager.gameOver == false && GameManager.gamePaused == false)
        {
            gameManager.GameHasStarted();
            if (Input.GetMouseButtonDown(0) && GameManager.gameHasStarted == true)
            {
                Go();
                //column spawner
                //columnSpawner.InstantiateColumn();
                
            }
            
            
        }

        timer += Time.deltaTime;
        timerE += Time.deltaTime;
        if (timer >= secondsToPoint && GameManager.gameOver == false)
        {
            score.Scored();
            timer = 0;
        }
        if (timerE >= secondsToDrain && GameManager.gameOver == false && GameManager.gameHasStarted == true)
        {
            myEnergy.energyLoss();
            timerE = 0;
            
        }
        if (Energy.noEnergy == true)
        {
            gameManager.GameOver();
            GameOver();
        }
    }

    void Go()
    {
        if (GameManager.gameOver == false)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (GameManager.gameOver == false)
        {
            if (coll.CompareTag("Column"))
            {
                //print("Passed through pipes");
            }
            else if (coll.CompareTag("Pipe"))
            {
                //game over
                hitEffect.SetTrigger("hit");
                gameManager.GameOver();
                GameOver();
            }
            else if (coll.CompareTag("Bullet"))
            {
                //game over
                hitEffect.SetTrigger("hit");
                gameManager.GameOver();
                GameOver();
            }
            else if (coll.CompareTag("Enemy"))
            {
                hitEffect.SetTrigger("hit");
                gameManager.GameOver();
                GameOver();
            }
            else if (coll.CompareTag("Enemy+"))
            {
                hitEffect.SetTrigger("hit");
                gameManager.GameOver();
                GameOver();
            }
            else if (coll.CompareTag("EnemyBird"))
            {
                hitEffect.SetTrigger("hit");
                gameManager.GameOver();
                GameOver();
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && walkPastEnemy == false)
        {
            hitEffect.SetTrigger("hit");
            gameManager.GameOver();
            GameOver();
        }
        if (collision.gameObject.CompareTag("Enemy+") && walkPastEnemy == false)
        {
            hitEffect.SetTrigger("hit");
            gameManager.GameOver();
            GameOver();
        }
        if (collision.gameObject.CompareTag("EnemyBird") && walkPastEnemy == false)
        {
            hitEffect.SetTrigger("hit");
            gameManager.GameOver();
            GameOver();
        }
    }

    void GameOver()
    {
        anim.enabled = false;
        if (Energy.noEnergy == true)
        {
            hitEffect.SetTrigger("hit");
            sp.sprite = playerTired;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            MenuManager.animate = false;
        }
        else
        {
            sp.sprite = playerDied;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            MenuManager.animate = true;
        }

    }
}
