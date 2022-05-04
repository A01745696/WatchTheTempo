using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    //Health System
    public Image ear_health;
    public Image wrist_health;
    public Image normal_health;
    private int maxValue = 100;
    //Loose Win Screen
    public GameObject gameover;
    public GameObject victoryscreen;
    public GameObject weapons;

    public Text LooserScore;
    public Text victorySore;

    //Pause Panel
    public GameObject panelPause;
    public bool paused = false;

    public static HUD instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ear_health.fillAmount = (float)PlayerHealth.health_ear/maxValue;
        wrist_health.fillAmount = (float)PlayerHealth.health_wrist / maxValue;
        normal_health.fillAmount = (float)PlayerHealth.health_normal / maxValue;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void UpdateEar(int i)
    {
        PlayerHealth.health_ear += i;
        ear_health.fillAmount = (float)PlayerHealth.health_ear / maxValue;
    }
    public void UpdateWrist(int i)
    {
        PlayerHealth.health_wrist += i;
        wrist_health.fillAmount = (float)PlayerHealth.health_wrist / maxValue;
    }
    public void UpdateNormal(int i)
    {
        PlayerHealth.health_normal += i;
        normal_health.fillAmount = (float)PlayerHealth.health_normal / maxValue;

        if (PlayerHealth.health_normal < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameover.SetActive(true);
        weapons.SetActive(false);
        LooserScore.text = PlayerHealth.score.ToString();
        Time.timeScale = 0;
    }
    public void VictoryScreen()
    {
        victoryscreen.SetActive(true);
        weapons.SetActive(false);
        victorySore.text = PlayerHealth.score.ToString();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Tienda()
    {
        SceneManager.LoadScene("Tienda1");
    }

    public void Pause()
    {
        paused = !paused;
        panelPause.SetActive(paused);

        Time.timeScale = paused ? 0 : 1;
    }
}
