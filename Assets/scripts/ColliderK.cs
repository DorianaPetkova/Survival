using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderK : MonoBehaviour
{

    [SerializeField] public SpriteRenderer interactionSprite;


    public GameObject textWater;

    public GameObject textStove;
    public GameObject textAfter;

    public GameObject towel;
    public GameObject ex;
    public GameObject firelong;

    public GameObject colliderFire;
    public GameObject colliderWater;
    public GameObject colliderTowel;
    public GameObject colliderStove;
    public GameObject colliderExit;
    public GameObject colliderEx;

    public static bool usedW = false;
    public static bool fireOff = false;



    void Start()
    {
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;


        if (textAfter != null)
            textAfter.SetActive(false);
        if (towel != null)
            towel.SetActive(true);
        if (ex != null)
            ex.SetActive(true);

        if (colliderStove != null)
            colliderStove.SetActive(false);

        if (colliderExit != null)
            colliderExit.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionSprite.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionSprite.enabled = false;
        }
    }
    void Update()
    {

        if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E))
        {
            if (textWater != null)
            {
                textWater.SetActive(true);
                usedW = true;
                colliderWater.SetActive(false);
                firelong.SetActive(true);
                colliderTowel.SetActive(false);
            }

            if (towel != null)
            {
                colliderFire.SetActive(true);
                towel.SetActive(false);
                fireOff = true;
                colliderEx.SetActive(false);

            }

            /*if (extinguisher.fireOff1)
            {
                colliderFire.SetActive(true);
                Debug.Log("ex should be true");
                Debug.Log($"{extinguisher.fireOff1}");
                if (textStove != null && extinguisher.fireOff1 == true)
                {
                    textStove.SetActive(true);
                    Debug.Log("so we have text stove, we have it true");
                    //clue.SetActive(false);
                    if (colliderStove != null && TextCanvasManager.textOff)
                    {
                        colliderStove.SetActive(true);
                        colliderFire.SetActive(false);
                        colliderTowel.SetActive(false);
                        Debug.Log("TELL ME WHY");
                    }

                }
            }
*/
            if (fireOff)
            {
                colliderWater.SetActive(false);
                colliderFire.SetActive(true);
                Debug.Log("true1");
                colliderTowel.SetActive(false);


                if (textStove != null && fireOff == true)
                {
                    textStove.SetActive(true);
                    //clue.SetActive(false);
                    if (colliderStove != null && !TextCanvasManager.textOff)
                    {
                        colliderStove.SetActive(true);
                        colliderFire.SetActive(false);
                        colliderTowel.SetActive(false);
                        Debug.Log("AINT NOTHING BUT A MISTAKE");
                    }
                }

                if (TextCanvasManager.textOff)
                {
                    colliderTowel.SetActive(false);
                    textAfter.SetActive(true);
                    Debug.Log("OH TELL ME WHY");
                    textStove.SetActive(false);
                    colliderFire.SetActive(false);

                }

            }
            if (extinguisher.fireOff1)
            {
                colliderWater.SetActive(false);
                colliderFire.SetActive(true);
                Debug.Log("true1 ex");
                colliderTowel.SetActive(false);


                if (textStove != null && extinguisher.fireOff1)
                {
                    textStove.SetActive(true);
                    //clue.SetActive(false);
                    if (colliderStove != null && !TextCanvasManager.textOff)
                    {
                        colliderStove.SetActive(true);
                        colliderFire.SetActive(false);
                        colliderTowel.SetActive(false);
                        Debug.Log("AINT NOTHING BUT A MISTAKE EX");
                    }
                }

                if (TextCanvasManager.textOff)
                {
                    colliderTowel.SetActive(false);
                    textAfter.SetActive(true);
                    Debug.Log("OH TELL ME WHY");
                    textStove.SetActive(false);
                    colliderFire.SetActive(false);

                }

            }

        }


        /*if (TextCanvasManager.textOff)
        {
            clue.SetActive(false);
        }*/
    }

}