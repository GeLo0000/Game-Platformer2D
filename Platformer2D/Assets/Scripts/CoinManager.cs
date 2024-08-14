using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinText();
    }

    public void SpendCoins(int amount)
    {
        coinCount -= amount;
        if (coinCount < 0) coinCount = 0;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
        coinText.text = coinCount.ToString();
    }
}
