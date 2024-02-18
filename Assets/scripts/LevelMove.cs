using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMove : MonoBehaviour
{
    public static int sceneBuildIndexPass;
    public int sceneBuildIndex;
    public bool NextScene = true;
    public bool isThirdDoor = false;
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
            // check if the E button should trigger the scene change
            if (CheckForEButton)
            {
                // show the sprite when the player enters the collider
                if (interactionSprite != null)
                {
                    interactionSprite.enabled = true;

                }
            }
            else
            {
                // load the new scene automatically
                LoadScene();

            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            // hide the sprite when the player exits the collider
            if (interactionSprite != null)
            {

                interactionSprite.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (interactionSprite != null)
        {
            if (playerInside && interactionSprite.enabled && interactionSprite != null && Input.GetKeyDown(KeyCode.E))
            {
                LoadScene();
            }
        }
    }
    private void LoadScene()
    {
        sceneinfo.NextScene = NextScene;
        sceneinfo.isThirdDoor = isThirdDoor;
        sceneBuildIndexPass = sceneBuildIndex;
        SceneManager.LoadScene(sceneBuildIndex);
       
    }


}
