using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.animate == false)
        {
            anim.enabled = false;
        }
        else
        {
            anim.enabled = true;
        }
    }
}
