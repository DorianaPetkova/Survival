using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // declaring the songs and attaching them to sources
    public AudioClip cuteSong;
    public AudioClip earthquakeMusic;
    public AudioClip sirensMusic;
    public AudioClip gameFinishedSound;
    public AudioClip elevatormusic;
    public AudioClip ding;
    public AudioClip fail;
    public AudioClip win;
    private bool visited2 = false;
    private AudioSource audioSource;

    private AudioSource audioSourceE;
    private AudioSource audioDing;
    private AudioSource audioSiren;
    private AudioSource audiogameFinished;
    private AudioSource audioWin;
    private AudioSource audioFail;
    private AudioSource audioearthquake;
    //declaring check-ins for future events
    public static bool el { get; set; } = false;
    public static bool quake { get; set; } = false;
    public static bool Squake { get; set; } = false;



    void Start()
    {
        // object persistent between scenes
        AudioManager[] managers = FindObjectsOfType<AudioManager>();

        // destroy duplicates of audiomanager
        if (managers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(gameObject);

            // getting the audiosource
            audioSource = GetComponent<AudioSource>();
            audioSourceE = gameObject.AddComponent<AudioSource>();
            audioDing = gameObject.AddComponent<AudioSource>();
            audioSiren = gameObject.AddComponent<AudioSource>();
            audiogameFinished = gameObject.AddComponent<AudioSource>();
            audioWin = gameObject.AddComponent<AudioSource>();
            audioFail = gameObject.AddComponent<AudioSource>();
            audioearthquake = gameObject.AddComponent<AudioSource>();


            // attaching clips and playing the menu song
            audioSource.clip = cuteSong;
            audioSourceE.clip = elevatormusic;
            audioDing.clip = ding;
            audioFail.clip = fail;
            audioWin.clip = win;
            audioearthquake.clip = earthquakeMusic;

            audioSiren.clip = sirensMusic;
            audiogameFinished.clip = gameFinishedSound;
            audiogameFinished.Play();

            //adjusting volume and loop
            audioSource.volume = 0.5f;
            audiogameFinished.volume = 0.5f;
            audioSiren.volume = 0.5f;
            audioSourceE.volume = 0.5f;

            audioSource.loop = true;
            audioSourceE.loop = true;
            audioSiren.loop = true;
            audiogameFinished.loop = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

    }
    void Update()
    {
        //CHECK IF IT WORKS

        if (SceneManager.GetActiveScene().buildIndex == 10 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            CheckKeyInput();
        }
        //checks for paused menu
        if (mainMenu.earthquakePaused)
            audioearthquake.Pause();
        else
            audioearthquake.UnPause();


    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // audio is triggered by the scene index
        switch (scene.buildIndex)
        {
            case 0:
                visited2 = false;

                audioSource.Pause();
                audioSiren.Pause();
                audioSourceE.Pause();
                audiogameFinished.UnPause();

                break;
            case 1:

                audiogameFinished.Pause();
                if (!visited2)
                    audioSource.Play();
                else
                    audioSource.UnPause();

                break;
            case 2:
                visited2 = true;
                break;
            case 9:

                audioSourceE.Pause();
                audioSource.UnPause();

                break;
            case 10:
                audioSource.Pause();
                if (el == false)
                {
                    audioSourceE.Play();
                    el = true;
                }
                else
                { audioSourceE.UnPause(); }
                break;
            case 11:
                audioSourceE.Pause();
                if (!Squake)
                    audioSource.UnPause();
                else
                    audioSource.Stop();
                break;
            case 12:
                audioSource.Pause();
                quake = true;
                if (!Squake)
                {
                    Squake = true;
                    audioearthquake.Play();

                    StartCoroutine(PlaySirensAfterEarthquake());
                }
                break;
            case 26:
                audioSource.Pause();
                audioSiren.Pause();
                audioSourceE.Pause();
                audiogameFinished.UnPause();
                visited2 = false;

                break;

            case 27:
                audioSource.Pause();
                audioSiren.Pause();
                audioSourceE.Pause();
                audiogameFinished.UnPause();
                audioFail.Play();
                visited2 = false;

                

                break;
            case 28:
                if (Ebutton.gotit)
                    audioWin.Play();

                break;
            case 29:
                audioSiren.Pause(); audioSource.Pause();
                audioSiren.Pause();
                audioSourceE.Pause();
                audiogameFinished.UnPause();
                audioWin.Play();
                
                break;
            case 31:
                audioSiren.Play();
                audioSource.Pause();
                break;

        }
    }



    void CheckKeyInput()
    {
        if (Elevator2.playerInsideCollider)
        // if the key is pressed, play ding
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                audioDing.Play();
            }
        }
        if (Elevatorscript.playerInsideCollider)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioDing.Play();
            }
        }
    }

    IEnumerator PlaySirensAfterEarthquake()
    {
        // wait until the earthquake sound finishes playing
        while (audioearthquake.isPlaying || audioearthquake.time < audioearthquake.clip.length)
        {
            yield return null;
        }
        audioSiren.Play();
    }
}
