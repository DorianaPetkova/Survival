using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject textCanvas;
    public GameObject clue;

    void Start()
    {
        if (clue != null)
            clue.SetActive(false);

        if (popupCanvas != null)
            popupCanvas.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 12)
            if (textCanvas != null)
                textCanvas.SetActive(false);

        // Check if the scene has been visited before showing textCanvas
        if (!GameController.Instance.SceneVisited && textCanvas != null)
        {
            textCanvas.SetActive(true);
            Debug.Log("textCanvas should be visible initially");
        }
        else if (GameController.Instance.SceneVisited && textCanvas != null)
        {
            // Scene has been visited, hide textCanvas
            textCanvas.SetActive(false);
            Debug.Log("textCanvas should be hidden after HideText is called");
            if (clue != null)
            {
                clue.SetActive(true);
            }
        }

    }
    void Update()
    {
        // Check if the scene index is 12 and isShaking is true
        if (SceneManager.GetActiveScene().buildIndex == 12 && Shake.isShaking && Shake.shakeTimeRemaining <= 0)
        {
            // Make textCanvas visible
            if (textCanvas != null && !textCanvas.activeSelf)
            {
                textCanvas.SetActive(true);
                Debug.Log("textCanvas should be visible");
            }
        }
    }

    public void ShowPauseMenu()
    {

        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
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

        Debug.Log("HideText has been called, textCanvas is permanently hidden");


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
