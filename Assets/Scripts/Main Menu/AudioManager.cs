using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{

    // ===================================== DECLARATIONS =====================================
    //Message in the unity interface
    [Header("----------- Audio Source -----------")]
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] AudioSource SFXgrass;
    [SerializeField] AudioSource SFXbirds;

    [Header("----------- Audio Clip -----------")]

    public AudioClip backgroundMusicMMenu;
    public AudioClip backgroundMusiclvl2;
    public AudioClip birds;
    public AudioClip treeWind;
    public AudioClip stepsGrass;

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

        }

        if (NumScene == 3)
        {
            Debug.Log("Este es el start que solo se ve en la escena 3");
            musicSource.Stop();

            //SI
            musicSource.clip = backgroundMusiclvl2;

            //NO
            SFXbirds.clip = birds;
            SFXbirds.Play();

            //SI
            SFXgrass.clip = stepsGrass;
        }
    }

    

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);    
    }

    public void TouchColliderSoundf(Collider other)
    {
        if (other.gameObject.layer == 7)
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
}
