using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Message in the unity interface
    [Header("----------- Audio Source -----------")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] AudioSource SFXgrass;
    [SerializeField] AudioSource SFXbirds;

    [Header("----------- Audio Clip -----------")]

    public AudioClip backgroundMusic;
    public AudioClip birds;
    public AudioClip treeWind;
    public AudioClip stepsGrass;

    private bool playerIsMoving = true;


    //public AudioClip clickSound;

    public static AudioManager instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //This starts when the scene charges
    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();

        SFXbirds.clip = birds;
        SFXbirds.Play();

        SFXgrass.clip = stepsGrass;

    }

    void Update()
    {
        IsPlayerMoving();
        
        if (!SFXgrass.isPlaying)
        {
            IsMovingGrass();
        }
        
    }

    //Gets a clip of audio and plays it
    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);    
    }

    public void TouchColliderSoundf()
    {

    }

    public void IsMovingGrass()
    {
        if(playerIsMoving)
        {
            Debug.Log("I'm walking on grass!");
            SFXgrass.Play();
        }
    }

    public void IsPlayerMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerIsMoving = true;
            Debug.Log("Im pressing it!");
        }
        else
        {
            playerIsMoving = false;
            Debug.Log("QUIETO!");
            SFXgrass.Stop();
        }
    }
}
