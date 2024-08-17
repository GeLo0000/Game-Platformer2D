using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public GameObject lockObject;
    public GameObject ButtonForOpen;
    public GameObject purchaseButton;
    public CoinManager coinManager;

    private bool isPurchased;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        isPurchased = PlayerPrefs.GetInt("IsCharacterPurchased", 0) == 1;

        if (isPurchased)
        {
            lockObject.SetActive(false);
            purchaseButton.SetActive(false);
            ButtonForOpen.SetActive(true);
        }
    }

    public void OnPurchaseButtonClicked()
    {
        if (PlayerPrefs.GetInt("CoinCount", 0) >= 9)
        {
            audioManager.PlaySFX(audioManager.buttonCoinsBuyClick);
            lockObject.SetActive(false);
            purchaseButton.SetActive(false);
            ButtonForOpen.SetActive(true);
            PlayerPrefs.SetInt("IsCharacterPurchased", 1);
            PlayerPrefs.Save();
            coinManager.SpendCoins(9);
        }
    }
}
