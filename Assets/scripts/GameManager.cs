using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public Transform playerTransform;
    //public Dictionary<int, Vector3> SceneLastVisitedCoordinates = new Dictionary<int, Vector3>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private Vector2 defaultPosition = new Vector2(105, 86);
    private bool scene1Visited = false;
    private Vector2 coordinatesScene1;

    private void Start()
    {
        // Load the last visited scene and coordinates
        LoadGame();

        // Check if the current scene is Scene1 and if it has been visited
        if (SceneManager.GetActiveScene().name == "CityScene 1" && !scene1Visited)
        {
            // If not visited, set the player position to the default position
            SetPlayerPosition(defaultPosition);
        }
        else
        {
            // If visited, set the player position to the saved coordinates
            SetPlayerPosition(coordinatesScene1);
        }
    }
    private void OnSceneUnloaded(Scene scene)
    {
        // Save the last visited scene and player coordinates when a scene is unloaded
        if (scene.buildIndex == SceneManager.GetSceneByName("CityScene 1").buildIndex)
        {
            // Save the game only if the player decides to leave the scene
            SaveGame();
        }
    }
    private void SetPlayerPosition(Vector2 position)
    {
        if (playerTransform != null)
        {
            // Assign the new position to the player's transform
            playerTransform.position = position;
        }
        else
        {
            Debug.LogError("Player transform not assigned in GameManager.");
        }
    }

    public void SaveGame()
    {
        // Save the visited state and player coordinates
        PlayerPrefs.SetInt("Scene1Visited", scene1Visited ? 1 : 0);
        PlayerPrefs.SetFloat("CoordinatesScene1X", coordinatesScene1.x);
        PlayerPrefs.SetFloat("CoordinatesScene1Y", coordinatesScene1.y);

        // Save the data to disk
        PlayerPrefs.Save();
    }

    private void LoadGame()
    {
        // Load the visited state and player coordinates
        scene1Visited = PlayerPrefs.GetInt("Scene1Visited", 0) == 1;
        coordinatesScene1.x = PlayerPrefs.GetFloat("CoordinatesScene1X", defaultPosition.x);
        coordinatesScene1.y = PlayerPrefs.GetFloat("CoordinatesScene1Y", defaultPosition.y);
    }



    // Save the last visited coordinates when a scene is unloaded
    /*private void OnDisable()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Vector3 playerPosition = playerObject.transform.position;

            if (SceneLastVisitedCoordinates.ContainsKey(currentSceneIndex))
            {
                SceneLastVisitedCoordinates[currentSceneIndex] = playerPosition;
                Debug.Log($"Default?? {currentSceneIndex}: {playerPosition}");
            }
            else
            {
                SceneLastVisitedCoordinates.Add(currentSceneIndex, playerPosition);
                Debug.Log($"New {currentSceneIndex}: {playerPosition}");
            }


        }
        else
        {
            Debug.LogError("Player not found when saving coordinates.");
        }
    }*/

}
