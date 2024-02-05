using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collider1;
    public GameObject colliderW;
    public GameObject collider2;
    public GameObject colliderF;
    public GameObject colliderEntrance;
    public GameObject colliderStairs;
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.clue4)
        {
            if (colliderW != null)
            {
                colliderW.SetActive(true);
                Debug.Log("win");
                Debug.Log(Ebutton.clue4);
            }

            if (collider1 != null)
                collider1.SetActive(false);
            if (colliderEntrance != null)
                colliderEntrance.SetActive(false);
        }
        if (!Ebutton.clue4)
            if (colliderStairs != null)
                colliderStairs.SetActive(false);

        if (Shake.clue3)
        {
            if (colliderF != null)
                colliderF.SetActive(true);
            if (collider2 != null)
                collider2.SetActive(false);
        }
    }
}
