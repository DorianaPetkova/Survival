using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip cuteSong;
    public AudioClip earthquakeMusic;
    public AudioClip sirensMusic;
    public AudioClip gameFinishedSound;
    public AudioClip elevatormusic;
    public AudioClip ding;
    public AudioClip fail;
    public AudioClip win;

    private AudioSource audioSource;

    private AudioSource audioSourceE;
    private AudioSource audioDing;
    private AudioSource audioSiren;
    private AudioSource audiogameFinished;
    private AudioSource audioWin;
    private AudioSource audioFail;

    public static bool el { get; set; } = false;
    public static bool quake { get; set; } = false;
    public static bool Squake { get; set; } = false;

    void Start()
    {
        // Make this object persistent between scenes
        AudioManager[] managers = FindObjectsOfType<AudioManager>();

        // If there's more than one AudioManager, destroy the duplicates
        if (managers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Make this object persistent between scenes
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource component
            audioSource = GetComponent<AudioSource>();
            audioSourceE = gameObject.AddComponent<AudioSource>();
            audioDing = gameObject.AddComponent<AudioSource>();
            audioSiren = gameObject.AddComponent<AudioSource>();
            audiogameFinished = gameObject.AddComponent<AudioSource>();
            audioWin = gameObject.AddComponent<AudioSource>();
            audioFail = gameObject.AddComponent<AudioSource>();


            // Start playing the cute song throughout the game
            audioSource.clip = cuteSong;
            audioSourceE.clip = elevatormusic;
            audioDing.clip = ding;
            audioFail.clip = fail;
            audioWin.clip = win;

            audioSiren.clip = sirensMusic;
            audiogameFinished.clip = gameFinishedSound;
            audiogameFinished.Play();

            audioSource.volume = 0.5f;
            audiogameFinished.volume = 0.5f;
            audioSiren.volume = 0.5f;
            audioSourceE.volume = 0.5f;

            audioSource.loop = true;
            audioSourceE.loop = true;
            audioSiren.loop = true;
            audiogameFinished.loop = true;

            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            CheckKeyInput();

        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the scene number and trigger audio events accordingly
        switch (scene.buildIndex)
        {
            case 0:
                audioSource.Pause();
                audiogameFinished.UnPause();
                break;
            case 1:
                audiogameFinished.Pause();
                audioSource.Play();
                break;
            case 9:
                // Assuming elevatorMusic is an AudioClip assigned in the Inspector
                audioSourceE.Pause();
                audioSource.UnPause();


                break;
            case 10:
                // Scene 9: Stop cute music, play elevator sound
                audioSource.Pause();

                // Assuming elevatorMusic is an AudioClip assigned in the Inspector
                if (el == false)
                {
                    audioSourceE.Play();
                    el = true;
                }
                else
                { audioSourceE.UnPause(); }
                break;

            case 11:

                // Scene 11: Unpause cute song
                // Assuming elevatorMusic is an AudioClip assigned in the Inspector
                audioSourceE.Pause();
                if (!Squake)
                    audioSource.UnPause();
                else
                    audioSource.Stop();
                break;

            case 12:
                // Scene 12: Play earthquake music, then play sirens music
                audioSource.Pause();
                quake = true;
                if (!Squake)
                {
                    PlayOneShot(earthquakeMusic);
                    Squake = true;
                    Invoke("PlaySirensMusic", earthquakeMusic.length);
                }
                break;
            case 27:
                audioSiren.Pause();

                audioFail.Play();
                Debug.Log("fail");
                audiogameFinished.UnPause();
                break;
            case 28:
                if (Ebutton.gotit)
                    audioWin.Play();
                Debug.Log("win");

                break;
            case 29:
                audioSiren.Pause();
                audioWin.Play();
                audiogameFinished.UnPause();
                Debug.Log("win");
                break;

        }
    }

    void PlayBackgroundMusic(AudioClip audioClip)
    {
        // Play background music
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }


    void PlayOneShot(AudioClip audioClip)
    {
        // Play a one-shot sound effect
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    void PlaySirensMusic()
    {


        // Play sirens music
        audioSiren.Play();
    }
    void CheckKeyInput()
    {
        // Check for key presses and play elevator sound
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioDing.Play();
        }
    }
}
