using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOpenManager : MonoBehaviour
{
    public GameObject lockObject;
    public GameObject ButtonAfterOpen;
    public GameObject openingButton;
    public KeysManager keysManager;
    public bool isGold;
    public string nameObject;

    private bool isOpened;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        isOpened = PlayerPrefs.GetInt(nameObject, 0) == 1;

        if (isOpened)
        { 
            lockObject.SetActive(false);
            openingButton.SetActive(false);
            ButtonAfterOpen.SetActive(true);
        }
    }

    public void OnOpenButtonClicked()
    {
        if (isGold)
        {
            if (PlayerPrefs.GetInt("goldKeyCount", 0) >= 1)
            {
                CloseOpenButtons();
                keysManager.SpendGoldKey(1);
                audioManager.PlaySFX(audioManager.buttonKyesOpenClick);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("silverKeyCount", 0) >= 1)
            {
                CloseOpenButtons();
                keysManager.SpendSilverKey(1);
                audioManager.PlaySFX(audioManager.buttonKyesOpenClick);
            }
        }
        
    }
    void CloseOpenButtons()
    {
        lockObject.SetActive(false);
        openingButton.SetActive(false);
        ButtonAfterOpen.SetActive(true);
        PlayerPrefs.SetInt(nameObject, 1);
        PlayerPrefs.Save();
    }
}
