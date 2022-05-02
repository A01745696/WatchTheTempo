using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    //Bullet/Note speed
    private float Speed = 6;

    //Components
    private Rigidbody2D rb;
    private Vector2 Direction;

    private void Start()
    {
        InvokeRepeating("DestroyNote", 3, 1);
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Hit();
            DestroyNote();
        }
    }
}
