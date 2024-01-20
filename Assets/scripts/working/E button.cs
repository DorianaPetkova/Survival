using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ebutton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public SpriteRenderer interactionSprite;
    [SerializeField] public string sceneToLoad;

    private void Start()
    {
        // Ensure the script starts with the sprite disabled.
        interactionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        interactionSprite.enabled = false;
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
        // Check if the player is inside the trigger and pressed 'E'.
        if (interactionSprite.enabled && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
