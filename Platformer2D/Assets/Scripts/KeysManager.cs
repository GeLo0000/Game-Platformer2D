using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeysManager : MonoBehaviour
{
    public TextMeshProUGUI goldKeyText;
    private int goldKeyCount = 0;

    public TextMeshProUGUI silverKeyText;
    private int silverKeyCount = 0;

    void Start()
    {
        goldKeyCount = PlayerPrefs.GetInt("goldKeyCount", 0);
        silverKeyCount = PlayerPrefs.GetInt("silverKeyCount", 0);
        UpdateGoldKeyText();
        UpdateSilverKeyText();
    }

    public void AddSilverKey(int amount)
    {
        silverKeyCount += amount;
        UpdateSilverKeyText();
    }

    public void SpendSilverKey(int amount)
    {
        silverKeyCount -= amount;
        if (silverKeyCount < 0) silverKeyCount = 0;
        UpdateSilverKeyText();
    }

    private void UpdateSilverKeyText()
    {
        PlayerPrefs.SetInt("silverKeyCount", silverKeyCount);
        PlayerPrefs.Save();
        silverKeyText.text = silverKeyCount.ToString();
    }

    public void AddGoldKey(int amount)
    {
        goldKeyCount += amount;
        UpdateGoldKeyText();
    }

    public void SpendGoldKey(int amount)
    {
        goldKeyCount -= amount;
        if (goldKeyCount < 0) goldKeyCount = 0;
        UpdateGoldKeyText();
    }

    private void UpdateGoldKeyText()
    {
        PlayerPrefs.SetInt("goldKeyCount", goldKeyCount);
        PlayerPrefs.Save();
        goldKeyText.text = goldKeyCount.ToString();
    }
}
