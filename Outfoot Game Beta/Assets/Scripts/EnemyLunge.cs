using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLunge : MonoBehaviour
{
    // Start is called before the first frame update
    float lungeSpeed;

    Rigidbody2D rb;
    Vector2 moveDirection;
    Player target;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lungeSpeed = MovePrefab.prefabSpeed * 1.2f;
        rb.velocity = -transform.right * lungeSpeed;
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //lungeSpeed = MovePrefab.prefabSpeed + 0.3f;
    }

}
