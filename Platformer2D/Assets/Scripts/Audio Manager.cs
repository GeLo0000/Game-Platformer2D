using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source -------")]
    public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- AudioClip -------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip buttonCoinsBuyClick;
    public AudioClip buttonKyesOpenClick;
    public AudioClip jump;
    public AudioClip coinsGet;
    public AudioClip keysGet;
    public AudioClip damage;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;
    public AudioClip finish;


    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayButton()
    {
        SFXSource.PlayOneShot(buttonClick);
    }
}
