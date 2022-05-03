using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private float limit;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x + 4f;
            if (position.x > 0 && position.x < limit)
                transform.position = position;
        }
    }
}
