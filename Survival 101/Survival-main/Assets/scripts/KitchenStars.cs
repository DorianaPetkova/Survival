using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenStars : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private static KitchenStars instance;
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 29)
        {
            string selectedLevel = GameController.Instance.selectedLevel;
            if (selectedLevel == "FireHazzard")
            {
                star1.SetActive(true);
                if (ColliderK.usedW && !TextCanvasManager.nofire)
                {
                    star3.SetActive(false);
                    star2.SetActive(false);

                }
                if (ColliderK.usedW && TextCanvasManager.nofire)
                {
                    star3.SetActive(false);
                    star2.SetActive(true);

                }
                if (!ColliderK.usedW && !TextCanvasManager.nofire)
                {
                    star3.SetActive(false);
                    star2.SetActive(true);

                }
                if (!ColliderK.usedW && TextCanvasManager.nofire)
                {
                    star3.SetActive(true);
                    star2.SetActive(true);
                }


            }
            if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 26 || SceneManager.GetActiveScene().buildIndex == 27 || SceneManager.GetActiveScene().buildIndex == 32 || SceneManager.GetActiveScene().buildIndex == 33)
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
            }
        }
        else
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
}
