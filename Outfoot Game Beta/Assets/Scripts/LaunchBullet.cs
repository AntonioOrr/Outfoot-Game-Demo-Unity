using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f;
    public int damage = 1;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        EnemyBird enemyB = hitInfo.GetComponent<EnemyBird>();
        EnemyBoss enemyC = hitInfo.GetComponent<EnemyBoss>();
        if (hitInfo.CompareTag("Enemy") )
        {
            enemy.TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("EnemyBird"))
        {
            enemyB.TakeDamage(damage);
        }
        else if (hitInfo.CompareTag("EnemyBoss"))
        {
            enemyC.TakeDamage(damage);
        }
        if (!hitInfo.CompareTag("Bullet") || hitInfo.CompareTag("Offscreen") || hitInfo.CompareTag("Ground"))
        Destroy(gameObject);
    }
}
