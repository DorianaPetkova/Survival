using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    public GameObject collider1;
    public GameObject colliderW;
    public GameObject collider2;
    public GameObject colliderF;
    public GameObject colliderEntrance;
    public GameObject colliderStairs;
    public GameObject colliderkitchen;
    public GameObject colliderWinK;
    


    void Start()
    {
        //activating colliders based on events in the game
        if (colliderStairs != null)
            colliderStairs.SetActive(true);
        if (colliderEntrance != null)
            colliderEntrance.SetActive(true);
        if (collider1 != null)
            collider1.SetActive(true);
        if (collider2 != null)
            collider2.SetActive(true);
        if (colliderW != null)
            colliderW.SetActive(false);
        if (colliderF != null)
            colliderF.SetActive(false);
        if (colliderWinK != null)
            colliderWinK.SetActive(false);
        

    }


    void Update()
    {
        
        if (TextCanvasManager.textOff)
        {
            colliderWinK.SetActive(true);
            colliderkitchen.SetActive(false);
            Debug.Log("why are u not registering");
        }

        if (Ebutton.clue4)
        {
            if (colliderW != null)
            {
                colliderW.SetActive(true);
                Debug.Log("colliderwin active");
            }

            if (collider1 != null)
            {
                collider1.SetActive(false);
                Debug.Log("collider from city to entrance false");
            }
            if (colliderEntrance != null)
                colliderEntrance.SetActive(false);
        }
        if (!Ebutton.clue4)
            if (colliderStairs != null)
                colliderStairs.SetActive(false);

        if (Shake.clue3)
        {
            if (colliderF != null)
            {
                colliderF.SetActive(true);
                Debug.Log($"collider fail true");
            }
            if (collider2 != null)
            {
                collider2.SetActive(false);
                Debug.Log($"collider 2 false");
                Debug.Log($"{Shake.clue3}");
            }
        }
    }
}
