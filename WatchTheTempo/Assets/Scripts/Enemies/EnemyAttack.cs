using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : NoteScript
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HUD.instance.UpdateNormal(-Random.Range(10,20));
            PlayerHealth.score -= 50;
            PlayerHealth.multiplier = 0.1f;
        }
    }
}
