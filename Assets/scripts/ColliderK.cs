using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderK : MonoBehaviour
{

    [SerializeField] public SpriteRenderer interactionSprite;
    public GameObject clue;
    public GameObject textWater;

    public GameObject textStove;
    public GameObject textAfter;

    public GameObject towel;
    public GameObject colliderStove;
    public GameObject colliderWater;
    public GameObject colliderTowel;
    public GameObject colliderStove1;
    public GameObject colliderExit;
    public static bool usedW = false;
    public static bool fireOff = false;

    void Start()
    {
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;
        if (clue != null)
            clue.SetActive(false);
        if (textAfter != null)
            textAfter.SetActive(false);
        if (towel != null)
            towel.SetActive(true);
        if (colliderStove != null)
            colliderStove.SetActive(false);
        if (colliderStove1 != null)
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
            }

            if (towel != null)
            {
                towel.SetActive(false);
                fireOff = true;
                
            }

            if (fireOff)
            {
                colliderWater.SetActive(false);
                colliderStove.SetActive(true);
                colliderTowel.SetActive(false);
                if (textStove != null && fireOff == true)
                {
                    textStove.SetActive(true);
                    clue.SetActive(false);
                    if (colliderStove1 != null && !TextCanvasManager.textOff)
                    {
                        colliderStove1.SetActive(true);
                        colliderStove.SetActive(false);


                    }
                }
                if (TextCanvasManager.textOff)
                {
                    textAfter.SetActive(true);
                    textStove.SetActive(false);
                    

                }

            }

        }
        if (mainMenu.cluek3 && !fireOff)
        {
            clue.SetActive(true);
            
        }
    }

}