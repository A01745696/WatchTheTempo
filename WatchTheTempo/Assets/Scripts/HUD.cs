using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Image ear_health;
    public Image wrist_health;
    public Image normal_health;

    private int maxValue = 100;

    public static HUD instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ear_health.fillAmount = (float)PlayerHealth.instance.health_ear/maxValue;
        wrist_health.fillAmount = (float)PlayerHealth.instance.health_wrist / maxValue;
        normal_health.fillAmount = (float)PlayerHealth.instance.health_normal / maxValue;
    }

    public void UpdateEar(int i)
    {
        PlayerHealth.instance.health_ear += i;
        ear_health.fillAmount = (float)PlayerHealth.instance.health_ear / maxValue;
    }
    public void UpdateWrist(int i)
    {
        PlayerHealth.instance.health_wrist += i;
        wrist_health.fillAmount = (float)PlayerHealth.instance.health_wrist / maxValue;
    }
    private void UpdateNormal(int i)
    {
        PlayerHealth.instance.health_normal += i;
        normal_health.fillAmount = (float)PlayerHealth.instance.health_normal / maxValue;
    }


}
