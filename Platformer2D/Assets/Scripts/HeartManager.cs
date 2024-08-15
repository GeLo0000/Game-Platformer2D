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

    public void TakeDamage()
    {
        currentIndex --;
        heartImages[currentIndex].SetActive(false);
        
        if (currentIndex <= 0)
        {
            pauseButton.SetActive(false);
            deathMenu.Pause();
        }
    }
}
