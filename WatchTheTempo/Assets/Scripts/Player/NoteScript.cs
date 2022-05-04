using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    //Bullet/Note speed
    private float Speed = 8;
    private float points = 200; 

    //Components
    private Rigidbody2D rb;
    private Vector2 Direction;

    private void Start()
    {
        InvokeRepeating("DestroyNote", 2.5f, 1);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyNote()
    {
        Destroy(gameObject);
        PlayerHealth.multiplier = 0.1f;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Detecta Enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            try
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Hit();
            } catch
            {
                WolfEnemy enemy = collision.gameObject.GetComponent<WolfEnemy>();
                enemy.Hit();
            }
            
            DestroyNote();
            PlayerHealth.score += (int)(points + points * PlayerHealth.multiplier);
            PlayerHealth.multiplier += 0.1f;
        }
    }

}
