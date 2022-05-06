using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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
    public int idInstrumento;

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

    public void GameOver()
    {
        weapons.SetActive(false);
        gameover.SetActive(true);
        LooserScore.text = PlayerHealth.score.ToString();
        StartCoroutine(SubirTextoPlano());
        PlayerHealth.score = 0;
        PlayerHealth.health_ear = 100;
        PlayerHealth.health_wrist = 100;
        PlayerHealth.health_normal = 100;
        Time.timeScale = 0;
    }
    public void VictoryScreen()
    {
        victoryscreen.SetActive(true);
        weapons.SetActive(false);
        victorySore.text = PlayerHealth.score.ToString();
        StartCoroutine(SubirTextoPlano());
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
    public void Boss()
    {
        SceneManager.LoadScene("Boss Level");
    }

    public void Pause()
    {
        paused = !paused;
        panelPause.SetActive(paused);

        Time.timeScale = paused ? 0 : 1;
    }

    private IEnumerator SubirTextoPlano()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("ID_Jugador", "sopas");
        forma.AddField("Puntuacion", 9999);
        forma.AddField("ID_Personaje", 1);
        forma.AddField("ID_Instrumento", idInstrumento);
        forma.AddField("ID_Nivel", SceneManager.GetActiveScene().buildIndex);
        forma.AddField("Tiempo", (int)Time.fixedTime);

        UnityWebRequest request = UnityWebRequest.Post("http://snowker.xyz/phpmyadmin/registraDatos.php", forma);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string textoPlano = request.downloadHandler.text;
            print(textoPlano);
        }
        else
        {
            print("Error al descargar: " + request.responseCode.ToString());
        }
    }

}
