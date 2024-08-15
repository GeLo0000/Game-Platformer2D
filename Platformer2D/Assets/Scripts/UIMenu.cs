using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    public GameObject menuPanel;
    void Update()
    {
        
    }
    public void Pause()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
