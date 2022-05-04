using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.health_ear = 100;
        PlayerHealth.health_wrist = 100;
        PlayerHealth.health_normal = 100;
        PlayerHealth.score = 0;

    }

}
