using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameController").AddComponent<GameController>();
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    // Add any other variables or methods related to game state here
    public string selectedCharacter;
    public string selectedLevel;
    public static bool sceneVisited { get; set; } = false;
    public static bool sceneVisited1 { get; set; } = false;
    public static bool sceneVisited2 { get; set; } = false;
    public static bool sceneVisited3 { get; set; } = false;
    public static bool sceneVisited4 { get; set; } = false;

    public bool SceneVisited
    {
        get { return sceneVisited; }
        set { sceneVisited = value; }
    }
    public bool SceneVisited1
    {
        get { return sceneVisited1; }
        set { sceneVisited1 = value; }
    }
    public bool SceneVisited2
    {
        get { return sceneVisited2; }
        set { sceneVisited2 = value; }
    }
    public bool SceneVisited3
    {
        get { return sceneVisited3; }
        set { sceneVisited3 = value; }
    }
    public bool SceneVisited4
    {
        get { return sceneVisited4; }
        set { sceneVisited4 = value; }
    }

}
