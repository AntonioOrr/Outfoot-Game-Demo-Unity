using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public static float prefabSpeed = 0.6f;
    float acceleration;

    BoxCollider2D box;
    float groundWidth;

    float pipeWidth;

    CapsuleCollider2D caps;
    float enemyWidth;
    float enemy3Width;
    float enemyBirdWidth;

    // Start is called before the first frame update
    void Start()
    {
        //prefabSpeed = 0.6f;
        acceleration = 0.002f;
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("Column"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x;
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            enemyWidth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CapsuleCollider2D>().size.x;
        }
        else if (gameObject.CompareTag("Enemy+"))
        {
            enemy3Width = GameObject.FindGameObjectWithTag("Enemy+").GetComponent<CapsuleCollider2D>().size.x;
        }
        else if (gameObject.CompareTag("EnemyBird"))
        {
            enemyBirdWidth = GameObject.FindGameObjectWithTag("EnemyBird").GetComponent<CapsuleCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.gameOver == false)
        {
            increasePrefSpeed();
            transform.position = new Vector2(
                transform.position.x - prefabSpeed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(
                    transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Column"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - 3 * pipeWidth)
                Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - enemyWidth)
                Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Enemy+"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - enemy3Width)
                Destroy(gameObject);
        }
        else if (gameObject.CompareTag("EnemyBird"))
        {
            if (transform.position.x < GameManager.bottomLeft.x - enemyBirdWidth)
                Destroy(gameObject);
        }
    }

    public void increasePrefSpeed()
    {
        prefabSpeed += Time.deltaTime * acceleration;
    }

}
