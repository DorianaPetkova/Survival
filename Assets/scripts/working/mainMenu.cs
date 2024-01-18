using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

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
    }

    public void StartButton()
    {
        SceneManager.LoadScene("CityScene 1");
    }
}
