using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject menuPanel;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Pause()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
        audioManager.musicSource.Pause();
    }

    public void Continue()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
        audioManager.musicSource.Play();
    }
}
