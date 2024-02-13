using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textWater;
    public GameObject fire;
    public GameObject textStove;
    public GameObject textFire;
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
    }

    // Update is called once per frame
    void Update()
    {

    }
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
            if (fire != null)
                fire.SetActive(false);
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
            Debug.Log("works?");
            Debug.Log($"{nofire}");
            colliderStove1.SetActive(false);

        }
        // set the visited state using the GameController
        GameController.Instance.SceneVisited4 = true;
    }
}
