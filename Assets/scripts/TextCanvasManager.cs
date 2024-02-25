using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextCanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textWater;
    public GameObject fire;
    public GameObject firelong;

    public GameObject textStove;
    public GameObject textFire;

    public GameObject colliderStove1;
    public GameObject clueFire;
    public GameObject clueFire1;


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
        if (firelong != null)
            firelong.SetActive(false);
        if (clueFire1 != null)
            clueFire1.SetActive(false);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 32)
        {
            clueFire1.SetActive(false);
        }
    }


    // Update is called once per frame

    public void HideText()
    {
        if (textWater != null)
        {
            textWater.SetActive(false);
            firelong.SetActive(true);
            Debug.Log("long fire??");

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
    public void HideText1()
    {

        if (textStove != null)
        {
            clueFire.SetActive(false);
            textStove.SetActive(false);
            clueFire1.SetActive(true);
            //textExit.SetActive(true);
            colliderStove1.SetActive(true);

            Debug.Log("AINT NOTHING BUT A HEARTACHE");
            if (fire != null)
            {
                fire.SetActive(false);
                firelong.SetActive(false);
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
            Debug.Log("WHYYYY");
            nofire = true;
            colliderStove1.SetActive(false);

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
}
