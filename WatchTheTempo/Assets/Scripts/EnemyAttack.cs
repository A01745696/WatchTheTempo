using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == Player.tag)
        {
            print("sopas");
        }
    }
}
