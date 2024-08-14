using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject activeCharacter;

    void Start()
    {
        /*PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs have been cleared.");*/
        SpawnCharacter();
    }

    public void ChangeCharacter(int newCharacterIndex)
    {
        if (newCharacterIndex >= 0 && newCharacterIndex < characterPrefabs.Length)
        {
            PlayerPrefs.SetInt("SelectedCharacterIndex", newCharacterIndex);
            PlayerPrefs.Save();
            SpawnCharacter();
        }
    }

    void SpawnCharacter()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            if (activeCharacter != null)
            {
                Destroy(activeCharacter);
            }

            activeCharacter = Instantiate(characterPrefabs[selectedCharacterIndex], transform.position, transform.rotation);
        }
    }
}
