using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ebutton : MonoBehaviour
{

    [SerializeField] public SpriteRenderer interactionSprite;

    public GameObject flashlight;
    public GameObject textCanvas;

    public static bool clue4 { get; set; } = false;
    public static bool gotit { get; set; } = false;


    private void Start()
    {
        // the script starts when the sprite is disabled
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;
        if (flashlight != null)
            flashlight.SetActive(false);

        if (textCanvas != null)
            textCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionSprite.enabled = true;
        }
    }
    public void HideText()
    {//hiding the text canvas through button
        if (textCanvas != null)
        {
            textCanvas.SetActive(false);
            clue4 = true;
            Debug.Log($"clue 4 is: {clue4}");

        }
        GameController.Instance.SceneVisited3 = true;


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
        //checking if the e is down and if character is in collider, then activating the sprite
        if (SceneManager.GetActiveScene().buildIndex == 28)
        {
            if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E) && !gotit)
            {
                if (flashlight != null)
                    flashlight.SetActive(true);
                StartCoroutine(DisableFlashlightAfterDelay(3f));
                gotit = true;
                StartCoroutine(ShowCanvasAfterDelay(3f));
            }

        }
        else if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(LevelMove.sceneBuildIndexPass);
        }
    }

    IEnumerator DisableFlashlightAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // disable the flashlight after waiting for 2 seconds
        if (flashlight != null)
        {
            flashlight.SetActive(false);
        }
    }
    IEnumerator ShowCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //showing the canvas after the flashlight's hidden
        if (textCanvas != null)
        {
            textCanvas.SetActive(true);
        }
    }
}

