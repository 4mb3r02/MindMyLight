using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Message in the unity interface
    [Header("----------- Audio Source -----------")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip -----------")]

    public AudioClip backgroundMusic;
    public AudioClip clickSound;

    //This starts when the scene charges
    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    //Gets a clip of audio and plays it
    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);    
    }
}
