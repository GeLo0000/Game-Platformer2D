using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject pauseButton;
    public UIMenu finishMenu;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            pauseButton.SetActive(false);
            finishMenu.Pause();
        }
    }
}
