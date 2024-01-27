using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatorscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject upArrowSprite;
    public GameObject downArrowSprite;
    private bool playerInsideCollider;
    public GameObject glidingObject1; // The object to be glided
    public GameObject glidingObject2;
    public float glideDistance1 = 117.0f; // Adjust the distance to glide
    public float glideDistance2 = 119.0f;
    public float glideSpeed = 2.0f;
    private Vector3 originalPosition1; // Store the original position of the first gliding object
    private Vector3 originalPosition2; //



    void Start()
    {
        // Disable both arrow sprites at the start
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
            // Player entered the collider
            playerInsideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the collider
            playerInsideCollider = false;
            downArrowSprite.SetActive(false);
            upArrowSprite.SetActive(false);
            GlideObject(originalPosition1, glideDistance1, glidingObject1);

            // Glide the second object back to its original position
            GlideObject(originalPosition2, glideDistance2, glidingObject2);
        }
    }

    void Update()
    {
        if (playerInsideCollider)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Player pressed the UpArrow key
                ShowUpArrowEffect();
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);


            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Player pressed the DownArrow key
                ShowDownArrowEffect();
                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);

            }
        }



    }

    private void ShowUpArrowEffect()
    {
        // Logic to show sprite child 1 (up arrow effect)
        // For example, you might enable a particle system, change sprite color, etc.
        upArrowSprite.SetActive(true);
        downArrowSprite.SetActive(false); // Optional: Hide the down arrow
    }

    private void ShowDownArrowEffect()
    {
        // Logic to show sprite child 2 (down arrow effect)
        // For example, you might enable a particle system, change sprite color, etc.
        downArrowSprite.SetActive(true);
        upArrowSprite.SetActive(false); // Optional: Hide the up arrow
    }
    private void GlideObject(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        // Smoothly move the object to the target position
        StartCoroutine(GlideObjectCoroutine(targetPosition, distance, glidingObject));
    }
    private void GlideObject1(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        // Smoothly move the object to the target position
        StartCoroutine(GlideObjectCoroutine(targetPosition, distance, glidingObject));
    }


    private IEnumerator GlideObjectCoroutine(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        float elapsedTime = 0f;
        glidingObject.SetActive(true);

        while (elapsedTime < glideSpeed)
        {
            glidingObject.transform.position = Vector3.Lerp(glidingObject.transform.position, targetPosition, elapsedTime / glideSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object reaches the target position precisely
        glidingObject.transform.position = targetPosition;
    }

}
