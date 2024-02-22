using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CluesManager : MonoBehaviour
{

    
    public GameObject office;
    public GameObject floor;
    public GameObject flashlight;
    public GameObject exit;
    void Start()
    {
        office.SetActive(false);
        flashlight.SetActive(false);
        exit.SetActive(false);
        floor.SetActive(false);
    }


    void Update()
    {
        //activating the clues based on the index and events
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 27 || SceneManager.GetActiveScene().buildIndex == 29|| SceneManager.GetActiveScene().buildIndex == 33)
        {
            office.SetActive(false);
            flashlight.SetActive(false);
            exit.SetActive(false);
            floor.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 7 && mainMenu.clue1)
        {
            flashlight.SetActive(false);
            exit.SetActive(false);
            floor.SetActive(false);
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
