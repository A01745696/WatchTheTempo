using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //LimitsY movement
    private static Vector2 LimitsY = new Vector2(0.58f, -3.41f);
    [SerializeField] public float leftlmit;
    [SerializeField] public float rightlmit;
    public bool boss = false;

    //Movement
    private float x;
    private float y;
    private float z;
    public int xspeed = 3;
    public int yspeed = 4;
    //States
    enum States { patrol, pursuit }
    [SerializeField] States state = States.patrol;
    //Shoot
    public GameObject enemyNote;
    private float lastShoot;

    //Target needed stuff
    Transform player;
    Vector3 target;
    Vector2 vel;
    float searchRange = 27;
    float runRange = 5;

    //Components
    protected Rigidbody2D rb;
    protected Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SetTarget", 0, 2.2f);
        
    }
    void SetTarget()
    {
        if (state != States.patrol)
        {
            return;
        }
        //Limits movement
        if (!boss)
        {
            target = new Vector2(Mathf.Clamp(transform.position.x + Random.Range(-runRange, runRange),
            leftlmit, rightlmit),
            Random.Range(LimitsY.y, LimitsY.x));
        }
        else
        {
            target = new Vector2(Mathf.Clamp(transform.position.x + Random.Range(-runRange, runRange),
            leftlmit, rightlmit),
            Random.Range(0, -6));
        }

    }
    private void Update()
    {

        if (state == States.pursuit)
        {
            target = player.transform.position;
            if (Vector3.Distance(target, transform.position) > runRange * 1.02f)
            {
                target = new Vector3 (transform.position.x, Random.Range(-runRange,runRange), transform.position.z);
                state = States.patrol;
                Shoot();
            }
        }
        else if (state == States.patrol)
        {
            var ob = Physics2D.BoxCast(transform.position, new Vector2(searchRange, 15), 0, Vector2.zero);
            if (ob.collider != null)
            {
                if (ob.collider.CompareTag("Player"))
                {
                    state = States.pursuit;
                    return;
                }
            }
        }

        vel = target - transform.position;
        if (target.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(x, y, z);
        }
        else { gameObject.transform.localScale = new Vector3(-x, y, z); }

        if (vel.magnitude < 0.3f)
            vel = Vector2.zero;

        vel.Normalize();

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            rb.velocity = Vector3.zero;

        rb.velocity = new Vector2(vel.x * xspeed, vel.y * yspeed);
    }
    //Destroy object if Hit
    public void Hit()
    {
        Destroy(gameObject);
    }
    //Shoot enemyNote
    void Shoot()
    {
        if (Time.time > lastShoot + 1f)
        {
            Vector3 direction;
            if (transform.localScale.x == x) direction = Vector2.right;
            else direction = Vector2.left;
            GameObject note = Instantiate(enemyNote, transform.position + direction * 1.5f, Quaternion.identity);
            note.GetComponent<NoteScript>().SetDirection(direction);
            lastShoot = Time.time;
        }
        
    }
    //Function to see enemy path and field of vision
    /*private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(searchRange, 15,1));
        Gizmos.DrawWireSphere(target, 1.0f);
    }*/
}
