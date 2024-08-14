using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public GameObject lockObject;
    public GameObject Button2;
    public GameObject purchaseButton;
    public CoinManager coinManager;

    private bool isPurchased;

    void Start()
    {
        isPurchased = PlayerPrefs.GetInt("IsCharacterPurchased", 0) == 1;

        if (isPurchased)
        {
            lockObject.SetActive(false);
            purchaseButton.SetActive(false);
            Button2.SetActive(true);
        }
    }

    public void OnPurchaseButtonClicked()
    {
        if (PlayerPrefs.GetInt("CoinCount", 0) >= 9)
        {
            lockObject.SetActive(false);
            purchaseButton.SetActive(false);
            Button2.SetActive(true);
            PlayerPrefs.SetInt("IsCharacterPurchased", 1);
            PlayerPrefs.Save();
            coinManager.SpendCoins(9);
        }
    }
}
