using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public static int sceneBuildIndexPass;
    public int sceneBuildIndex;
    public bool NextScene = true;
    public bool ThirdDoor = false;
    public bool CheckForEButton = false;
    [SerializeField] public SceneInfo sceneinfo;
    [SerializeField] public SpriteRenderer interactionSprite;
    private bool playerInside = false;
    private void Start()
    {
        if (interactionSprite != null)
        {
            interactionSprite.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (CheckForEButton) // Check if the E button should trigger the scene change
            {
                // Show the sprite when the player enters the collider
                if (interactionSprite != null)
                {
                    interactionSprite.enabled = true;
                    Debug.Log("INSIDE BUT NOT CLICKED");
                }
            }
            else
            {
                // Load the new scene automatically
                LoadScene();
                Debug.Log("THIS SHOULD NOT SHOW");
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            // Hide the sprite when the player exits the collider
            interactionSprite.enabled = false;
        }
    }

    private void Update()
    {
        // Check if the player is inside the trigger, sprite is enabled, and pressed 'E'.
        if (playerInside && interactionSprite.enabled && interactionSprite != null && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
            Debug.Log("BUTTON E CLICKED???");
        }
    }

    private void LoadScene()
    {
        sceneinfo.NextScene = NextScene;
        sceneBuildIndexPass = sceneBuildIndex; // Store the sceneBuildIndex
        SceneManager.LoadScene(sceneBuildIndex);
    }


}
