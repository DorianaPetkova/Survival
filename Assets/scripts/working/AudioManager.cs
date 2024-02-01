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

    private AudioSource audioSource;
    private AudioSource audioSourceE;
    private AudioSource audioDing;
    private bool el = false;
    public static bool quake { get; private set; } = false;

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


            // Start playing the cute song throughout the game
            audioSource.clip = cuteSong;
            audioSourceE.clip = elevatormusic;
            audioDing.clip = ding;
            audioSource.Play();




            // Subscribe to the scene loaded event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        /*DontDestroyOnLoad(gameObject);

        // Start playing the cute song throughout the game
        PlayBackgroundMusic(cuteSong);

        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;*/
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            CheckKeyInput();
            Debug.Log($"there should be a ding?");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the scene number and trigger audio events accordingly
        switch (scene.buildIndex)
        {
            case 9:
                // Assuming elevatorMusic is an AudioClip assigned in the Inspector
                audioSourceE.Pause();
                if (quake == false)
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
                audioSourceE.Stop();
                // Scene 11: Unpause cute song
                // Assuming elevatorMusic is an AudioClip assigned in the Inspector
                audioSourceE.Pause();
                audioSource.UnPause();
                break;

            case 12:
                // Scene 12: Play earthquake music, then play sirens music
                audioSource.Pause();
                quake = true;
                PlayOneShot(earthquakeMusic);
                StartCoroutine(PlaySirensMusic());
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

    IEnumerator PlaySirensMusic()
    {
        // Wait for the earthquake music to finish
        yield return new WaitForSeconds(earthquakeMusic.length);

        // Play sirens music
        PlayBackgroundMusic(sirensMusic);
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
