using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    Rigidbody2D rb;
    float random;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        random = Random.Range(2f, 4.5f);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
        {
            
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, random), ForceMode2D.Impulse);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
