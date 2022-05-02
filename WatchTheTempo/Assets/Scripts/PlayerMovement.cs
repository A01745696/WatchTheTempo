using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Speed
    public int xspeed = 6;
    public int yspeed = 4;

    //Movement and Limits for Y
    private float x;
    private float y;
    private float z;
    Vector2 cntrl;
    private static Vector2 LimitsY = new Vector2(1.8f, -2.8f);

    //Bullet
    public GameObject Note;
    public GameObject Note2;
    private float lastShoot;

    //UI
    public GameObject canvas;

    //Components
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }

    void Update()
    {
        //Movement
        cntrl = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        //Correct view
        if (cntrl.x > 0)
            gameObject.transform.localScale = new Vector3(x,y,z);
        
        if (cntrl.x < 0)
            gameObject.transform.localScale = new Vector3(-x, y, z);

        //Movement
        rb.velocity = new Vector2(cntrl.x * xspeed, cntrl.y * yspeed);

        //Limits in movement
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, LimitsY.y, LimitsY.x),
            transform.position.z);
        //Shoot Notes
        if (Input.GetKeyDown(KeyCode.Z) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
            HUD.instance.UpdateEar(-5);
            HUD.instance.UpdateWrist(-10);
        }
    }

    void Shoot()
    {
        //Direccion de la note (respecto al Jugador)
        Vector3 direction;
        if (transform.localScale.x == x) direction = Vector2.right;
        else direction = Vector2.left;

        //Dispara 1 Nota u otra
        float disparo = Random.Range(-2, 1);
        if (disparo >= 0) 
        {
            GameObject note = Instantiate(Note, transform.position + direction * 1.5f, Quaternion.identity);
            note.GetComponent<NoteScript>().SetDirection(direction);
        } else
        {
            GameObject note = Instantiate(Note2, transform.position + direction * 1.5f, Quaternion.identity);
            note.GetComponent<NoteScript>().SetDirection(direction);
        }
        
    }
}
