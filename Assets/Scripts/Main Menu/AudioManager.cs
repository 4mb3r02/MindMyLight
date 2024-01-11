using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{

    // ===================================== DECLARATIONS =====================================
    //Message in the unity interface
    [Header("----------- Audio Mixer -----------")]

    public AudioMixer audioMixer;

    [Header("----------- Audio Source -----------")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] AudioSource SFXgrass;
    [SerializeField] AudioSource SFXbirds;
    [SerializeField] AudioSource SFXshark;
    [SerializeField] AudioSource SFXwind;


    [Header("----------- Audio Clip -----------")]

    public AudioClip backgroundMusicMMenu;
    public AudioClip backgroundMusiclvl1;
    public AudioClip backgroundMusiclvl2;
    public AudioClip backgroundMusiclvl22;
    public AudioClip birds;
    public AudioClip treeWind;
    public AudioClip stepsGrass;
    public AudioClip sharkWave;

    private bool playerIsMoving = true;
    private int NumScene;


    //public AudioClip clickSound;

    public static AudioManager instance;


    // ===================================== ONENABLE / AWAKE / START / UPDATE =====================================

    private void OnEnable()
    {
        // Ejecutes OnSceneLoades
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    void Update()
    {
        //Debug.Log(scene);


        // Lvl 1
        if (NumScene == 2)
        {

        }
        // Lvl 2
        else if (NumScene == 3)
        {
            IsPlayerMoving();

            if (!SFXgrass.isPlaying)
            {
                IsMovingGrass();
            }
        }
    }

    // ===================================== METHODS =====================================
    
    // This method is called each time a scene is called
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        NumScene = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Escena cargada: " + scene.name);

        Debug.Log(NumScene);

        if (NumScene == 0)
        {
            musicSource.clip = backgroundMusicMMenu;
            musicSource.Play();
            SFXwind.Stop();

        }

        if (NumScene == 2)
        {
            // We are in chapter 1
            ChangeVolume(0.35f);
            SFXshark.clip = sharkWave;
            musicSource.Stop();
            musicSource.clip = backgroundMusiclvl1;
            musicSource.Play();

        }

        if (NumScene == 3)
        {
            // We are in chapter 2
            Debug.Log("This is the start that you can see in the scene 3");
            musicSource.Stop();

            musicSource.clip = backgroundMusiclvl2;

            SFXbirds.clip = birds;
            SFXbirds.Play();

            SFXgrass.clip = stepsGrass;
        }

        if(NumScene == 5)
        {
            ChangeVolume(0.55f);
            musicSource.Stop();
            SFXbirds.Stop();
            SFXgrass.Stop();

            musicSource.clip = backgroundMusiclvl22;
            SFXwind.Play();
            musicSource.Play();
        }
    }

    

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);    
    }

    public void TouchColliderSoundf(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("I'm starting the music!");
            StartMusic();
        }
    }

    public void IsMovingGrass()
    {
        if(playerIsMoving)
        {
            //Debug.Log("I'm walking on grass!");
            SFXgrass.Play();
        }
    }

    public void IsPlayerMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerIsMoving = true;
            //Debug.Log("Im pressing it!");
        }
        else
        {
            playerIsMoving = false;
            //Debug.Log("QUIETO!");
            SFXgrass.Stop();
        }
    }

    public void StartMusic()
    {
        if(musicSource.isPlaying)
        {
            Debug.Log("The music is alrready playing!!");
            return;
        }
        else
        {
            musicSource.Play();

        }
    }

    public void PlaySharkSonud()
    {
        SFXshark.Play();
    }

    public void ChangeVolume(float volume)
    {
        Debug.Log("Im changing the volume to" + volume);
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }
}
