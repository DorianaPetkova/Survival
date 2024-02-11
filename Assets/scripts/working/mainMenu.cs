using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject textCanvas;
    public GameObject textCanvas1;
    public static bool count { get; set; } = false;
    public static bool clue1 { get; set; } = false;
    public static bool clue2 { get; set; } = false;

    public static bool showmenu { get; set; } = false;
    public static bool earthquakePaused { get; set; } = false;

    // reference to the ShakeManager
    private Shake shakeManager;


    void Start()
    {
        shakeManager = Shake.Instance;
        if (popupCanvas != null)
            popupCanvas.SetActive(false);

        // check if the scene has been visited before showing textCanvas
        if (!GameController.Instance.SceneVisited && textCanvas != null)
        {
            textCanvas.SetActive(true);
        }
        else if (GameController.Instance.SceneVisited && textCanvas != null)
        {
            // scene visited, hide textCanvas
            textCanvas.SetActive(false);
        }
        if (!GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            textCanvas1.SetActive(true);

        }
        else if (GameController.Instance.SceneVisited1 && textCanvas1 != null)
        {
            textCanvas1.SetActive(false);
        }

    }


    public void ShowPauseMenu()
    {
        showmenu = true;
        Debug.Log($"showmenu during show :{showmenu}");
        if (AudioManager.Squake)
            earthquakePaused = true;

        if (textCanvas != null)
        {
            textCanvas.SetActive(false);

        }
        if (textCanvas1 != null)
        {
            textCanvas1.SetActive(false);

        }
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(true);
        }
        if (Timer.startedCounting)
        {
            Timer.startedCounting = false;
            count = true;
        }
        if (AudioManager.quake && Shake.isShaking)
        {
            shakeManager.StopShake();
        }

    }
    public void ResumeGame()
    {
        showmenu = false;
        Debug.Log($"showmenu during resume :{showmenu}");
        if (AudioManager.Squake)
            earthquakePaused = false;
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
        if (count)
        {
            if (!Timer.startedCounting)
            {
                Timer.startedCounting = true;
            }
        }
        if (AudioManager.quake && Shake.isShaking)
        {
            shakeManager.ResumeShake();
        }
    }
    public void HideText()
    {
        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
            clue1 = true;
        }
        // set the visited state using the GameController
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
        Reset();
    }
    public void GenderButton()
    {
        SceneManager.LoadScene("GenderSelection");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Reset();
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
    }
    public void Reset()
    {
        Shake.isShaking = false;
        AudioManager.quake = false;
        AudioManager.Squake = false;
        AudioManager.el = false;
        GameController.sceneVisited = false;
        GameController.sceneVisited1 = false;
        GameController.sceneVisited2 = false;
        GameController.sceneVisited3 = false;
        Ebutton.gotit = false;
        Ebutton.clue4 = false;
        Shake.clue3 = false;
        clue1 = false;
        clue2 = false;
        count = false;
        Shake.shook = false;

    }
    public void StartButton()
    {
        SceneManager.LoadScene("CityScene 1");
    }
}
