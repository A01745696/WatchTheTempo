using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfEnemy : MonoBehaviour
{
    //States for enemy
    enum States { patrol, pursuit }
    [SerializeField] States state = States.patrol;

    [SerializeField] float searchRange = 5f;
    [SerializeField] float stoppingDistance = 0.3f;

    //Movement to player
    Transform player;
    Vector3 target;
    Vector2 vel;
    //Limits
    private static Vector2 LimitsY = new Vector2(0.58f, -3.41f);
    [SerializeField] public float leftlmit;
    [SerializeField] public float rightlmit;
    //Coordinates
    private float x;
    private float y;
    private float z;
    //Speed
    public int xspeed = 4;
    public int yspeed = 2;
    //Atackk
    private float clawradius = 0.8f;
    //Components
    private Rigidbody2D rb;
    private Animator animator;
    public Transform claw;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SetTarget", 0, 3);
        InvokeRepeating("SendClaw", 0, 2);
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(target, 1.0f);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(claw.position, clawradius);
    }*/
    void SetTarget()
    {
        if (state != States.patrol)
        {
            return;
        }
        target = new Vector2(Mathf.Clamp(transform.position.x + Random.Range(-searchRange, searchRange),
            leftlmit, rightlmit),
            Random.Range(LimitsY.y, LimitsY.x));
    }
    void SendClaw()
    {
        if (state != States.pursuit)
            return;

        if (vel.magnitude != 0)
            return;

        Claw();

    }
    void Update()
    {
        if (state == States.pursuit)
        {

            target = player.transform.position;
            if (Vector3.Distance(target, transform.position) > searchRange * 1.02f)
            {
                target = transform.position;
                state = States.patrol;
                return;
            }
        }
        else if (state == States.patrol)
        {
            var ob = Physics2D.CircleCast(transform.position, searchRange, Vector2.up);
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
        
        if(target.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(x, y, z);
        } else { gameObject.transform.localScale = new Vector3(-x, y, z); }

        if (vel.magnitude < stoppingDistance)
            vel = Vector2.zero;
        vel.Normalize();



        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("Running", vel.magnitude != 0);
        }
        else { rb.velocity = Vector3.zero; }

        rb.velocity = new Vector2(vel.x * xspeed, vel.y * yspeed);
    }


    void Claw()
    {
        print("golpe");
        animator.SetTrigger("Attack");
        Vector2 clawPosition = claw.position;
        var ob = Physics2D.CircleCast(clawPosition, clawradius, Vector2.up);
        if (ob.collider != null)
        {
            if (ob.collider.gameObject != gameObject)
            {
                HUD.instance.UpdateNormal(-Random.Range(10,20));
                PlayerHealth.instance.score -= 50;
                PlayerHealth.instance.multiplier = 0.1f;
            }
        }
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
