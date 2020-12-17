using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 2;

    public GameObject bullet;

    float fireRate;
    float nextFire;

    SpriteRenderer sp;
    CapsuleCollider2D cap;
    public Sprite enemyDeath;
    public int enemyKillPoints = 25;
    public float fadeDelay = 0.1f;
    public float alphaValue = 0;
    bool oneShot;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Score.score += enemyKillPoints;
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
        oneShot = false;
        sp = GetComponent<SpriteRenderer>();
        cap = GetComponent<CapsuleCollider2D>();
        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfTimeToFire();
        int random = Random.Range(0,100);
        if (random < 10 && oneShot == false)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            oneShot = true;
        }
    }

    IEnumerator FadeOut(float aValue, float fadeTime)
    {
        float alpha = sp.color.a;
        for (float t = 0.0f; t < 0.1f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Lerp(alpha, aValue, t));
            sp.color = newColor;
            yield return null;

        }
        Destroy(gameObject);
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
