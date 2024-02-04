using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject textCanvas;
    public GameObject textCanvas1;
    public static bool clue1 { get; set; } = false;
    public static bool clue2 { get; set; } = false;


    void Start()
    {



        if (popupCanvas != null)
            popupCanvas.SetActive(false);

        // Check if the scene has been visited before showing textCanvas
        if (!GameController.Instance.SceneVisited && textCanvas != null)
        {
            textCanvas.SetActive(true);

        }
        else if (GameController.Instance.SceneVisited && textCanvas != null)
        {
            // Scene has been visited, hide textCanvas
            textCanvas.SetActive(false);


        }
        if (!GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            textCanvas1.SetActive(true);

        }
        else if (GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            // Scene has been visited, hide textCanvas

            textCanvas1.SetActive(false);


        }

    }


    public void ShowPauseMenu()
    {

        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
        }
        if (textCanvas1 != null)
        {
            textCanvas1.SetActive(false);
        }

        // Show the popupCanvas
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(true);
        }


    }
    public void ResumeGame()
    {

        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
    }
    public void HideText()
    {

        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
            clue1 = true;

        }


        // Set the visited state using the GameController
        GameController.Instance.SceneVisited = true;




    }
    public void HideText1()
    {
        if (textCanvas1 != null)
        {
            textCanvas1.SetActive(false);
            clue2 = true;

        }
        GameController.Instance.SceneVisited1 = true;

    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void GenderButton()
    {
        SceneManager.LoadScene("GenderSelection");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }


    }

    public void StartButton()
    {
        SceneManager.LoadScene("CityScene 1");
    }
}
