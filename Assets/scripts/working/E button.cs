using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ebutton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public SpriteRenderer interactionSprite;
    [SerializeField] public string sceneToLoad;
    public GameObject flashlight;
    public static bool gotit { get; set; } = false;


    private void Start()
    {
        // Ensure the script starts with the sprite disabled.
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;
        if (flashlight != null)
            flashlight.SetActive(false);
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

    private void Update()
    {
        if (sceneToLoad == "Janitor's closet")
        {
            if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E) && gotit)
            {
                if (flashlight != null)
                    flashlight.SetActive(true);
                StartCoroutine(DisableFlashlightAfterDelay(2f));
                gotit = true;
            }
        }
        else if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    IEnumerator DisableFlashlightAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Disable the flashlight after waiting for 2 seconds
        if (flashlight != null)
        {
            flashlight.SetActive(false);
        }
    }
}

