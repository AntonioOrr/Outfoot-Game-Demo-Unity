using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGround : MonoBehaviour
{
    BoxCollider2D box;
    float groundWidth;
    // Start is called before the first frame update
    void Start()
    {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuManager.animate == true)
        {
            transform.position = new Vector2(
                transform.position.x - 0.7f * Time.deltaTime, transform.position.y);
            if (gameObject.CompareTag("Ground"))
            {
                if (transform.position.x <= -groundWidth )
                {
                    transform.position = new Vector2(
                        transform.position.x + 2 * groundWidth -.1f, transform.position.y);
                }
            }

        }
        
    }
}
