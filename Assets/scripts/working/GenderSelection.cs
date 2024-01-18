using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenderSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMaleButtonClicked()
    {
        GameController.Instance.selectedCharacter = "Male";

    }

    public void OnFemaleButtonClicked()
    {
        GameController.Instance.selectedCharacter = "Female";

    }

    private void LoadLevelSelectionScene()
    {
        SceneManager.LoadScene("CityScene 1");
    }
}
