using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public static int spawnsPassed;
    public static int respawns;
    // Start is called before the first frame update
    void Start()
    {
        spawnsPassed = 0;
        respawns = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
