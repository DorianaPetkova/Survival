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
        //disabling colliders based on chosen level
        string selectedLevel = GameController.Instance.selectedLevel;

        if (selectedLevel == "Earthquake")
        {
            ColliderLevelE.SetActive(true);
            ColliderLevelF.SetActive(false);
            Debug.Log("set to earthquake");



        }
        if (selectedLevel == "FireHazzard")
        {
            ColliderLevelE.SetActive(false);
            ColliderLevelF.SetActive(true);
            Debug.Log("set to fire");

        }

    }
   

}
