using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private static CanvasManager instance;

    public GameObject canvas1; // Reference to the first canvas
    public GameObject canvas2; // Reference to the second canvas
    public GameObject textR; // Reference to the first canvas
    public GameObject textE;
    public GameObject textK;
    //public GameObject restaurantText;
    //public GameObject officeText;

    void Start()
    {
        if (instance != null && instance != this)
        {
            // Make sure there's only one instance of CanvasManager
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Making it persistent between scenes
        DontDestroyOnLoad(gameObject);

        // Ensure both canvases are deactivated initially
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        textR.SetActive(false);
        textE.SetActive(false);
        textK.SetActive(false);
        //restaurantText.SetActive(false);
        //officeText.SetActive(false);
    }

    void Update()
    {
        // Activate the canvases based on the selected level
        string selectedLevel = GameController.Instance.selectedLevel;
        if (selectedLevel == "Earthquake")
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            if (!mainMenu.move)
                textE.SetActive(true);
            else
                textE.SetActive(false);
            //if (!mainMenu.clue1)
            //officeText.SetActive(true);
        }
        else if (selectedLevel == "FireHazzard")
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            if (!mainMenu.move)
            {
                textR.SetActive(true);
                Debug.Log("fire should be false");
                Debug.Log($"{mainMenu.move}");
            }
            else
                textR.SetActive(false);
            //if (!mainMenu.cluek1)
            //restaurantText.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 29 || SceneManager.GetActiveScene().buildIndex == 27 || SceneManager.GetActiveScene().buildIndex == 26)
        {
            textR.SetActive(false);
            textE.SetActive(false);
            textK.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 30)
        {
            if (!mainMenu.cluek2)
                textK.SetActive(true);
            else
                textK.SetActive(false);
            Debug.Log($"kitchen text should be true in canvas manager");
        }
    }
}