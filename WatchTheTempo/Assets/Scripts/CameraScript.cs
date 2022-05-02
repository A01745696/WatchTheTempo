using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            if (position.x > 0)
                transform.position = position;
        }
    }
}
