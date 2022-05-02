using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health_normal = 100;
    public int health_ear = 100;
    public int health_wrist = 100;

    public static PlayerHealth instance;
    private void Awake()
    {
        instance = this;
    }
}
 