using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FireManager : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private static FireManager instance;
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 29)
        {
            if (kitchen.water == true)
            {
                star3.SetActive(false);
            }
            else
            {
                 star3.SetActive(true);
            }
            if (kitchen.fire == true)
            {
                star1.SetActive(true);
            }
            if (kitchen.stove == true)
            {
                star2.SetActive(true);
            }
        }
    }
}
