using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    private static Vector2 LimitsX = new Vector2(11.5f, -11.5f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HUD.instance.UpdateNormal(-Random.Range(20, 40));
            PlayerHealth.score -= 50;
            PlayerHealth.multiplier = 0.1f;
        }
    }
    private void Start()
    {
        gameObject.transform.localPosition = new Vector3(Random.Range(LimitsX.y, LimitsX.x), -8);
    }
    public void DestroyBeam()
    {
        Destroy(gameObject);
    } 
}
