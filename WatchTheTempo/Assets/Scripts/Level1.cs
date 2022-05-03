using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    GameObject[] enemies;
    GameObject player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemies.Length);
        if (enemies.Length == 0 && player.transform.position.x > 125)
        {
            HUD.instance.VictoryScreen();

        }
    }
}
