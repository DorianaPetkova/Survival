using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ColliderLevelE;
    public GameObject ColliderLevelF;
    private void Start()
    {
        string selectedLevel = GameController.Instance.selectedLevel;

        if (selectedLevel == "Earthquake")
        {

            ColliderLevelE.SetActive(true);
            ColliderLevelF.SetActive(false);
        }

        if (selectedLevel == "FireHazzard")
        {

            ColliderLevelE.SetActive(false);
            ColliderLevelF.SetActive(true);
        }
    }

}