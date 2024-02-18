using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    // Start is called before the first frame update
     public Canvas StarsE;
     public Canvas StarsF;
    void Start()
    {
        if(StarsE!=null)
        StarsE.enabled=false;
        if(StarsF!=null)
        StarsF.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        string selectedLevel = GameController.Instance.selectedLevel;
        if (selectedLevel == "Earthquake" && SceneManager.GetActiveScene().buildIndex == 29)
        {
            
            StarsF.enabled=false;
            StarsE.enabled=true;
        }
        else if (selectedLevel == "FireHazzard" && SceneManager.GetActiveScene().buildIndex == 29)
        {
            StarsF.enabled=true;
            StarsE.enabled=false;
        }
    }
}
