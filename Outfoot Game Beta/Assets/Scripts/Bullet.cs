using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.01f;
    private float nextFire = 0.0f;
    

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameOver == false && GameManager.gameHasStarted == true && Time.time*4.5f > nextFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        nextFire = Time.time*4.5f + fireRate;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
