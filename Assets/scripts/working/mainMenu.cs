using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject textCanvas;
    public GameObject textCanvas1;
    public GameObject clue;



    void Start()
    {

        if (clue != null)
            clue.SetActive(false);

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

            if (clue != null)
            {
                clue.SetActive(true);
            }
        }
        if (!GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            textCanvas1.SetActive(true);

        }
        else if (GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            // Scene has been visited, hide textCanvas

            textCanvas1.SetActive(false);

            if (clue != null)
            {
                clue.SetActive(true);
            }
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
        }


        // Set the visited state using the GameController
        GameController.Instance.SceneVisited = true;

        if (clue != null)
        {
            clue.SetActive(true);
        }


    }
    public void HideText1()
    {
        if (textCanvas1 != null)
        {
            textCanvas1.SetActive(false);
        }
        GameController.Instance.SceneVisited1 = true;

        if (clue != null)
        {
            clue.SetActive(true);
        }
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
