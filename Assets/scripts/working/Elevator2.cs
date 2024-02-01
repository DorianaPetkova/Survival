using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject one;
    public GameObject two;
    public GameObject colliderOne;
    public GameObject colliderTwo;
    public GameObject toOne;
    public GameObject toTwo;

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
            two.SetActive(false);
            one.SetActive(false);
            colliderOne.SetActive(false);
            colliderTwo.SetActive(false);

            if (glidingObject1 != null)
            {
                GlideObject(originalPosition1, glideDistance1, glidingObject1);
            }

            // Check if glidingObject2 is not null before calling GlideObject
            if (glidingObject2 != null)
            {
                GlideObject(originalPosition2, glideDistance2, glidingObject2);
            }

        }
    }

    void Update()
    {
        if (playerInsideCollider)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Player pressed the UpArrow key
                ShowUpArrowEffect();
                colliderOne.SetActive(true);
                toOne.SetActive(true);
                colliderOne.SetActive(true);


                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
                two.SetActive(false);
                toTwo.SetActive(false);
                colliderTwo.SetActive(false);


            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Player pressed the DownArrow key
                ShowDownArrowEffect();

                two.SetActive(true);
                toTwo.SetActive(true);
                colliderTwo.SetActive(true);


                GlideObject(originalPosition1 + Vector3.right * glideDistance1, glideDistance1, glidingObject1);
                GlideObject(originalPosition2 - Vector3.right * glideDistance2, glideDistance2, glidingObject2);
                colliderOne.SetActive(false);
                toOne.SetActive(false);
                colliderOne.SetActive(false);

            }
        }



    }

    private void ShowUpArrowEffect()
    {
        // Logic to show sprite child 1 (up arrow effect)
        // For example, you might enable a particle system, change sprite color, etc.
        one.SetActive(true);
        two.SetActive(false); // Optional: Hide the down arrow
        toOne.SetActive(true);
        toTwo.SetActive(false);
    }

    private void ShowDownArrowEffect()
    {
        // Logic to show sprite child 2 (down arrow effect)
        // For example, you might enable a particle system, change sprite color, etc.
        two.SetActive(true);
        one.SetActive(false); // Optional: Hide the up arrow
        toOne.SetActive(false);
        toTwo.SetActive(true);
    }
    private void GlideObject(Vector3 targetPosition, float distance, GameObject glidingObject)
    {
        // Smoothly move the object to the target position
        if (glidingObject != null && glidingObject.activeSelf)
        {
            // Smoothly move the object to the target position
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

        // Ensure the object reaches the target position precisely
        if (glidingObject != null)
        {
            glidingObject.transform.position = targetPosition;
        }
    }


}
