using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLvlPlayer : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] cameras;
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < players.Length)
        {
            players[selectedCharacterIndex].SetActive(true);
            cameras[selectedCharacterIndex].SetActive(true);
        }
    }
}
