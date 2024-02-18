using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenderSelection : MonoBehaviour
{
    public void OnMaleButtonClicked()
    {
        GameController.Instance.selectedCharacter = "Male";
    }
    public void OnFemaleButtonClicked()
    {
        GameController.Instance.selectedCharacter = "Female";
    }
}
