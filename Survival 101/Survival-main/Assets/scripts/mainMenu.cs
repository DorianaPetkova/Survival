using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenu : MonoBehaviour
{
    public GameObject popupCanvas;
    public GameObject textCanvas;
    public GameObject textCanvas1;
    public GameObject textCanvas2;
    public GameObject textCanvas3;
    public GameObject textCanvasKitchen;
    public GameObject firecollider;
    public GameObject clueFire;


    public static bool clue1 { get; set; } = false;
    public static bool clue2 { get; set; } = false;
    public static bool cluek1 { get; set; } = false;
    public static bool cluek2 { get; set; } = false;
    public static bool cluek3 { get; set; } = false;


    public static bool move { get; set; } = false;

    public static bool count { get; set; } = false;

    public static bool showmenu { get; set; } = false;
    public static bool earthquakePaused { get; set; } = false;

    // reference to the ShakeManager
    private Shake shakeManager;


    void Start()
    {
        shakeManager = Shake.Instance;
        if (popupCanvas != null)
            popupCanvas.SetActive(false);
        if (clueFire != null)
            clueFire.SetActive(false);
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
        if (!GameController.Instance.SceneVisited5 && textCanvas2 != null)
        {
            textCanvas2.SetActive(true);

        }
        else if (GameController.Instance.SceneVisited5 && textCanvas2 != null)
        {
            textCanvas2.SetActive(false);
        }
        if (!GameController.Instance.SceneVisited6 && textCanvas3 != null)
        {
            textCanvas3.SetActive(true);


        }
        else if (GameController.Instance.SceneVisited6 && textCanvas3 != null)
        {
            textCanvas3.SetActive(false);
        }
        if (textCanvas3 != null)
            textCanvas3.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        showmenu = true;

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
        if (textCanvas2 != null)
        {
            textCanvas2.SetActive(false);
        }
        if (textCanvas3 != null)
        {
            textCanvas3.SetActive(false);
        }
        if (textCanvasKitchen != null)
        {
            textCanvasKitchen.SetActive(false);
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
            move = true;
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
    public void HideText2()
    {
        if (textCanvas2 != null)
        {
            textCanvas2.SetActive(false);
            move = true;
            cluek1 = true;

        }
        GameController.Instance.SceneVisited5 = true;
    }
    public void HideText3()
    {
        if (textCanvas3 != null)
        {
            textCanvas3.SetActive(false);
            cluek2 = true;

        }
        GameController.Instance.SceneVisited6 = true;
    }
    public void HideTextK()
    {
        if (textCanvasKitchen != null)
        {
            textCanvasKitchen.SetActive(false);
            cluek3 = true;
            firecollider.SetActive(false);
            if (clueFire != null)
                clueFire.SetActive(true);
        }
    }
    public void Information()
    {
        string selectedLevel = GameController.Instance.selectedLevel;
        if (selectedLevel == "Earthquake")
        {


            SceneManager.LoadScene("EarthquakeInfo");


        }
        if (selectedLevel == "FireHazzard")
        {
            SceneManager.LoadScene("FireInfo");


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
        Reset();
    }
    public void GenderButton()
    {
        SceneManager.LoadScene("GenderSelection");
    }
    public void FinishedButton()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void MenuButton()
    {

        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
        }
        if (textCanvas1 != null)
        {
            textCanvas1.SetActive(false);
        }
        if (textCanvas2 != null)
        {
            textCanvas2.SetActive(false);
        }
        if (textCanvas3 != null)
        {
            textCanvas3.SetActive(false);
        }
        if (textCanvasKitchen != null)
        {
            textCanvasKitchen.SetActive(false);
        }
        SceneManager.LoadScene("MainMenu");
        Reset();
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
        cluek1 = false;
        cluek2 = false;
        cluek3 = false;


        Shake.shook = false;
        ColliderK.usedW = false;
        ColliderK.fireOff = false;
        TextCanvasManager.textOff = false;
        TextCanvasManager.nofire = false;

        extinguisher.fireOff1 = false;
        extinguisher.clueOFF = false;

    }
    public void StartButton()
    {
        SceneManager.LoadScene("CityScene 1");
        move = false;
    }
}
