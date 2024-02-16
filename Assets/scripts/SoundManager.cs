using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soundON;
    public GameObject soundOFF;
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("SoundManager").AddComponent<SoundManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        if (soundOFF != null)
            soundOFF.SetActive(false);

    }

    // Update is called once per frame
    public void SoundOff()
    {
        // Find the GameObject with the AudioSource component
        AudioListener.volume = 0;
        soundOFF.SetActive(true);
        soundON.SetActive(false);
    }
    public void SoundOn()
    {
        // Find the GameObject with the AudioSource component
        AudioListener.volume = 1;
        soundON.SetActive(true);
        soundOFF.SetActive(false);
    }


}
