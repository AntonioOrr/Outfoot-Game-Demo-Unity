using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    public int health = 1;
    public int birdKillPoints = 10;
    Animator anim;
    SpriteRenderer sp;
    Rigidbody2D rb;
    public float fadeDelay = 0.2f;
    public float alphaValue = 0;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            Score.score += 25;
        }
    }

    void Die()
    {
        Player.walkPastEnemy = true;
        StartCoroutine(FadeOut(alphaValue, fadeDelay));
        Player.walkPastEnemy = false;
        //Destroy(gameObject);
    }
    void Start()
    {

        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        speed = MovePrefab.prefabSpeed * 0.7f;
        rb.velocity = -transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = MovePrefab.prefabSpeed - 0.2f;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy+") || collision.gameObject.CompareTag("Pipe")
            || collision.gameObject.CompareTag("EnemyBoss"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy") || coll.CompareTag("Enemy+") || coll.CompareTag("Pipe") || coll.CompareTag("EnemyBoss"))
        {
            Destroy(gameObject);
        }
        
    }

    IEnumerator FadeOut(float aValue, float fadeTime)
    {
        float alpha = sp.color.a;
        for (float t = 0.0f; t < 0.2f; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(sp.color.r, sp.color.g, sp.color.b, Mathf.Lerp(alpha, aValue, t));
            sp.color = newColor;
            yield return null;

        }
        Destroy(gameObject);
    }
}
