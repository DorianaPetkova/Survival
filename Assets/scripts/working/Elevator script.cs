using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatorscript : MonoBehaviour
{
    //sprites to show, objects to be glided, colliders to activate
    public GameObject upArrowSprite;
    public GameObject downArrowSprite;
    private bool playerInsideCollider;
    public GameObject glidingObject1;
    public GameObject glidingObject2;
    //distance for gliding
    public float glideDistance1 = 117.0f;
    public float glideDistance2 = 119.0f;
    public float glideSpeed = 2.0f;
    // Store the original position of the first gliding object
    private Vector3 originalPosition1;
    private Vector3 originalPosition2;

    void Start()
    {
        // disabling arrow sprites
        glidingObject1.SetActive(true);
        glidingObject2.SetActive(true);
        upArrowSprite.SetActive(false);
        downArrowSprite.SetActive(false);

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
            downArrowSprite.SetActive(false);
            upArrowSprite.SetActive(false);
            if (glidingObject1 != null && glidingObject1.activeSelf)
                GlideObject(originalPosition1, glideDistance1, glidingObject1);
            // gliding to the original position
            if (glidingObject2 != null && glidingObject2.activeSelf)
                GlideObject(originalPosition2, glideDistance2, glidingObject2);
        }
    }
    void Update()
    {
        if (playerInsideCollider)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ShowUpArrowEffect();
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ShowDownArrowEffect();
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
            }
        }
    }
    private void ShowUpArrowEffect()
    {
        upArrowSprite.SetActive(true);
        downArrowSprite.SetActive(false);
    }
    private void ShowDownArrowEffect()
    {
        downArrowSprite.SetActive(true);
        upArrowSprite.SetActive(false);
    }
    private void GlideObject(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        // moving doors into position
        if (glidingObject.activeSelf && glidingObject != null)
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
        // smooth gliding to the position
        if (glidingObject != null)
        {
            glidingObject.transform.position = targetPosition;
        }
    }
}
