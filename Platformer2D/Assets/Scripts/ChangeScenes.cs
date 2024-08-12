using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeScene(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }
}
