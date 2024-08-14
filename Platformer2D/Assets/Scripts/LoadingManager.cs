using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public CharacterSelection characterSelection;
    public ChangeScenes changeScenes;
    public GameObject loading;
    private float animationDuration = 3f;
    
    public void StartLoading(int scene)
    {
        StartCoroutine(PlayAnimationAndChangeScene(scene));
    }

    private IEnumerator PlayAnimationAndChangeScene(int scene)
    {
        characterSelection.activeCharacter.GetComponent<Animator>().SetBool("IsLoading", true);
        loading.SetActive(true);

        yield return new WaitForSeconds(animationDuration);

        characterSelection.activeCharacter.GetComponent<Animator>().SetBool("IsLoading", false);

        loading.SetActive(false);

        changeScenes.ChangeScene(scene);
    }
}
