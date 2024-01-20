using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject maleCharacter;
    public GameObject femaleCharacter;


    private void Start()
    {
        // Load the selected character based on GameController information
        string selectedCharacter = GameController.Instance.selectedCharacter;

        if (selectedCharacter == "Male")
        {
            maleCharacter.SetActive(true);
            femaleCharacter.SetActive(false);
        }
        else if (selectedCharacter == "Female")
        {
            maleCharacter.SetActive(false);
            femaleCharacter.SetActive(true);
        }
        // Add additional conditions if you have more character options
    }
}
