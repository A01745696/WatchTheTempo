using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private static Vector2 LimitsY = new Vector2(11.5f, -11.5f);

    public GameObject BeamPrefab;
    public GameObject Enemy1;
    public GameObject Enemy2;

    private GameObject[] enemies;
    private int waves = 5;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        InvokeRepeating("beamAnimation", 3f, 6f);

        Instantiate(Enemy1, new Vector3(12f, Random.Range(-6, 0)), Quaternion.identity);
        Instantiate(Enemy1, new Vector3(12f, Random.Range(-6, 0)), Quaternion.identity);
        Instantiate(Enemy1, new Vector3(12f, Random.Range(-6, 0)), Quaternion.identity);

        Instantiate(Enemy2, new Vector3(-12f, Random.Range(-6, 0)), Quaternion.identity);
        Instantiate(Enemy2, new Vector3(-12f, Random.Range(-6, 0)), Quaternion.identity);
        waves--;
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemies.Length + "    " + waves);
        if(enemies.Length == 0 && waves > 0)
        {
            for (int i = 0; i < Random.Range(3, 7); i++)
            {
                Instantiate(Enemy1,new Vector3(12f, Random.Range(-6, 0)),Quaternion.identity);
            }

            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Instantiate(Enemy2, new Vector3(-12f, Random.Range(-6, 0)), Quaternion.identity);
            }
            waves--;
        }
        if (waves == 0)
        {
            enabled = false;
            HUD.instance.VictoryScreen();
        }
    }

    private void createBeam()
    {
        Instantiate(BeamPrefab);
    }
    private void beamAnimation()
    {
        animator.SetTrigger("Attack");
    }
}
