using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CluesManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static CluesManager instance;
    public GameObject office;
    public GameObject floor;
    public GameObject flashlight;
    public GameObject exit;
    void Start()
    {
        if (instance != null && instance != this)
        {
            // Destroy this new instance, as there can only be one
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Make sure this instance persists between scenes
        DontDestroyOnLoad(gameObject);
        office.SetActive(false);
        flashlight.SetActive(false);
        exit.SetActive(false);
        floor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 7 && mainMenu.clue1)
        {

            office.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
            office.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 11)
            floor.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex > 6 && SceneManager.GetActiveScene().buildIndex < 11 && mainMenu.clue2)
        {

            if (!Ebutton.clue4)
                floor.SetActive(true);
            else
                floor.SetActive(false);

        }
        if (SceneManager.GetActiveScene().buildIndex > 10 && SceneManager.GetActiveScene().buildIndex < 14 || SceneManager.GetActiveScene().buildIndex == 28)
        {
            if (Ebutton.clue4)
                flashlight.SetActive(false);
            else if (Shake.clue3)
            {
                flashlight.SetActive(true);

            }
        }
        if (SceneManager.GetActiveScene().buildIndex > 10 && SceneManager.GetActiveScene().buildIndex < 24 || SceneManager.GetActiveScene().buildIndex == 28)
        {
            if (Ebutton.clue4)
                exit.SetActive(true);

        }
    }
}
