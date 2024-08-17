using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public GameObject[] heartImages;
    public GameObject pauseButton;
    public UIMenu deathMenu;
    private int currentIndex = 3;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage()
    {
        currentIndex --;
        heartImages[currentIndex].SetActive(false);
        
        if (currentIndex <= 0)
        {
            audioManager.PlaySFX(audioManager.playerDeath);
            pauseButton.SetActive(false);
            deathMenu.Pause();
        }
        else
        {
            audioManager.PlaySFX(audioManager.damage);
            audioManager.PlaySFX(audioManager.enemyDeath);
        }
    }
}
