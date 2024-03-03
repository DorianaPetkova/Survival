using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extinguisher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject colliderEx;
    public GameObject colliderTowel;
    public GameObject colliderFire;
    public GameObject colliderWater;
    public GameObject colliderStove;

    public GameObject textStove;
    public GameObject textAfter;
    [SerializeField] public SpriteRenderer interactionSprite;
    public GameObject ex;
    public static bool fireOff1 = false;
    public static bool clueOFF = false;


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
            if (ex != null)
            {
                ex.SetActive(false);
                fireOff1 = true;
                colliderEx.SetActive(false);
                colliderTowel.SetActive(false);
                colliderFire.SetActive(true);

                Debug.Log("wtf");

            }
            if (ColliderK.fireOff)
            {
                colliderEx.SetActive(false);
            }
            /*if (fireOff1)
            {
                colliderWater.SetActive(false);
                colliderFire.SetActive(true);
                Debug.Log("true1 ex");
                colliderTowel.SetActive(false);
                colliderStove.SetActive(true);



                if (textStove != null && fireOff1 == true)
                {
                    textStove.SetActive(true);
                    Debug.Log("la da dee");

                    if (colliderStove != null && !TextCanvasManager.textOff)
                    {
                        colliderStove.SetActive(true);
                        colliderFire.SetActive(false);
                        colliderTowel.SetActive(false);
                        Debug.Log("why1 ex");
                        clueOFF = true;
                    }
                }
                if (TextCanvasManager.textOff)
                {
                    textAfter.SetActive(true);
                    textStove.SetActive(false);
                    colliderTowel.SetActive(false);
                }


            }*/
        }

    }
    void Start()
    {
        clueOFF = false;
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;

    }
}
