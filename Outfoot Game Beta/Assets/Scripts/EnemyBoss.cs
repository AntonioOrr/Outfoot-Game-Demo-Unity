using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 20;

    public GameObject bullet;

    float fireRate;
    float nextFire;

    SpriteRenderer sp;
    CapsuleCollider2D cap;
    public Sprite enemyDeath;
    public int bossKillPoints = 200;
    public float fadeDelay = 0.4f;
    public float alphaValue = 0;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Score.score += bossKillPoints;
        }
    }

    void Die()
    {
        sp.sprite = enemyDeath;
        Player.walkPastEnemy = true;
        StartCoroutine(FadeOut(alphaValue, fadeDelay));
        Player.walkPastEnemy = false;
        //Destroy(gameObject);
    }
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        cap = GetComponent<CapsuleCollider2D>();
        fireRate = 0.75f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
            CheckIfTimeToFire();
    }

    IEnumerator FadeOut(float aValue, float fadeTime)
    {
        float alpha = sp.color.a;
        for (float t = 0.0f; t < 0.4f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Lerp(alpha, aValue, t));
            sp.color = newColor;
            yield return null;

        }
        Destroy(gameObject);
        EnemySpawner.bossSpawned = false;
       // GameManager.startPhase3 = false;
       // GameManager.startPhase1 = true;
    }


    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
