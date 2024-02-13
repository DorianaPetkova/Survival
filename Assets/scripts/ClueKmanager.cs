using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueKmanager : MonoBehaviour
{
    // Start is called before the first frame update
    private static ClueKmanager instance;
    public GameObject restaurant;
    public GameObject kitchen;

    void Start()
    {
        if (instance != null && instance != this)
        {
            // make sure there's one instance
            Destroy(gameObject);
            return;
        }
        instance = this;

        //making it persistent between scenes
        DontDestroyOnLoad(gameObject);
        restaurant.SetActive(true);
        restaurant.SetActive(false);
        kitchen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 27 || SceneManager.GetActiveScene().buildIndex == 29)
        {
            restaurant.SetActive(false);
            kitchen.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 7 && mainMenu.cluek1)
        {
            restaurant.SetActive(true);
            kitchen.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 30)
        {
            if (!mainMenu.cluek2)
                restaurant.SetActive(false);
            if (mainMenu.cluek2)
            {
                kitchen.SetActive(true);
                restaurant.SetActive(false);
            }
            Debug.Log(" kitchen clue should be true");
            Debug.Log($"{mainMenu.cluek2}");
        }
        if (SceneManager.GetActiveScene().buildIndex == 31)
        {
            restaurant.SetActive(false);
            kitchen.SetActive(false);

        }
    }
}
