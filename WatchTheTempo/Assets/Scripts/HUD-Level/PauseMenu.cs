using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;
    public bool paused = false;

    PauseMenu instance;
    private void Awake()
    {
        instance = this;
    }

    public void Pause()
    {
        paused = !paused;
        panelPause.SetActive(panelPause);
        Time.timeScale = paused ? 0 : 1;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
