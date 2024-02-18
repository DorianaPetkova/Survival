using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    //almost the same script as elevator
    public GameObject one;
    public GameObject two;
    public GameObject colliderOne;
    public GameObject colliderTwo;
    public GameObject toOne;
    public GameObject toTwo;

    public static bool playerInsideCollider { get; set; } = false;
    private bool pressedOne = false;
    private bool pressedTwo = false;

    public GameObject glidingObject1;
    public GameObject glidingObject2;
    public float glideDistance1 = 117.0f;
    public float glideDistance2 = 119.0f;
    public float glideSpeed = 2.0f;
    private Vector3 originalPosition1;
    private Vector3 originalPosition2;



    void Start()
    {

        glidingObject1.SetActive(true);
        glidingObject2.SetActive(true);
        one.SetActive(false);
        two.SetActive(false);
        colliderOne.SetActive(false);
        colliderTwo.SetActive(false);
        toOne.SetActive(false);
        toTwo.SetActive(false);

        originalPosition1 = glidingObject1.transform.position;
        originalPosition2 = glidingObject2.transform.position;


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerInsideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerInsideCollider = false;
            if(two!=null)
            two.SetActive(false);
            if(one!=null)
            one.SetActive(false);
            if(colliderOne!=null)
            colliderOne.SetActive(false);
            if(colliderTwo!=null)
            colliderTwo.SetActive(false);

            if (glidingObject1 != null && glidingObject1.activeSelf)
            {
                GlideObject(originalPosition1, glideDistance1, glidingObject1);
            }


            if (glidingObject2 != null && glidingObject2.activeSelf)
            {
                GlideObject(originalPosition2, glideDistance2, glidingObject2);
            }
            pressedOne = false;
            pressedTwo = false;

        }
    }

    void Update()
    {
        if (playerInsideCollider)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                pressedOne = true;
                colliderOne.SetActive(true);
                if (!pressedTwo)
                {
                    toOne.SetActive(true);
                    toTwo.SetActive(false);
                    ShowUpArrowEffect();
                }
                else
                {
                    toOne.SetActive(false);
                    toTwo.SetActive(true);
                    ShowDownArrowEffect();
                }
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
                two.SetActive(false);
                colliderTwo.SetActive(false);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                pressedTwo = true;
                ShowDownArrowEffect();

                colliderTwo.SetActive(true);
                if (!pressedOne)
                {
                    toOne.SetActive(false);
                    toTwo.SetActive(true);
                    ShowDownArrowEffect();
                }
                else
                {
                    toOne.SetActive(true);
                    toTwo.SetActive(false);
                    ShowUpArrowEffect();
                }
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
                colliderOne.SetActive(false);
                colliderOne.SetActive(false);
            }

        }
    }
    private void ShowUpArrowEffect()
    {
        one.SetActive(true);
        two.SetActive(false);
        toOne.SetActive(true);
        toTwo.SetActive(false);
    }

    private void ShowDownArrowEffect()
    {
        two.SetActive(true);
        one.SetActive(false);
        toOne.SetActive(false);
        toTwo.SetActive(true);
    }
    private void GlideObject(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        if (glidingObject != null && glidingObject.activeSelf)
        {
            StartCoroutine(GlideObjectCoroutine(targetPosition, distance, glidingObject));
        }
    }
    private IEnumerator GlideObjectCoroutine(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        float elapsedTime = 0f;
        glidingObject.SetActive(true);

        while (glidingObject != null && elapsedTime < glideSpeed)
        {
            glidingObject.transform.position = Vector3.Lerp(glidingObject.transform.position, targetPosition, elapsedTime / glideSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (glidingObject != null)
        {
            glidingObject.transform.position = targetPosition;
        }
    }
}
