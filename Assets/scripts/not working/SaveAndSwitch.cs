using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the game when the player enters the collider
            if (GameManager.instance != null)
            {
                GameManager.instance.SaveGame();
            }
            else
            {
                Debug.LogError("GameManager instance not found.");
            }

            // Switch to the next scene
            SceneManager.LoadScene("CityScene 2");
        }
    }
}
