using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextCanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textWater;
    public GameObject fire;
    public GameObject textStove;
    public GameObject textFire;
    public GameObject textExit;
    public GameObject colliderStove1;

    public static bool textOff = false;
    public static bool nofire = false;
    void Start()
    {
        if (textWater != null)
            textWater.SetActive(false);
        if (textStove != null)
            textStove.SetActive(false);
        if (fire != null)
            fire.SetActive(true);
        if (textExit != null)
            textExit.SetActive(false);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 32)
            textExit.SetActive(false);
    }
    // Update is called once per frame

    public void HideText()
    {
        if (textWater != null)
        {
            textWater.SetActive(false);

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
    public void HideText1()
    {

        if (textStove != null)
        {

            textStove.SetActive(false);
            textExit.SetActive(true);
            if (fire != null)
            {
                fire.SetActive(false);

            }
            textOff = true;

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
    public void HideText2()
    {
        if (textFire != null)
        {
            textFire.SetActive(false);

            nofire = true;

            colliderStove1.SetActive(false);

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
}
