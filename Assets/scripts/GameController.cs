using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

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

    //making sure if gender isnt selected, default is male
    public string selectedCharacter = "Male";
    public string selectedLevel;
    //earthquake 1
    public static bool sceneVisited { get; set; } = false;
    //earthquake 2
    public static bool sceneVisited1 { get; set; } = false;
    //shake of earthquake
    public static bool sceneVisited2 { get; set; } = false;
    //e button flashlight
    public static bool sceneVisited3 { get; set; } = false;
    //KITCHEN
    public static bool sceneVisited4 { get; set; } = false;
    //not taken
    public static bool sceneVisited5 { get; set; } = false;
    //fire 1
    public static bool sceneVisited6 { get; set; } = false;
    //fire restaurant
    public static bool sceneVisited7 { get; set; } = false;
    //checks if scene has been visited
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
    public bool SceneVisited5
    {
        get { return sceneVisited5; }
        set { sceneVisited5 = value; }
    }
    public bool SceneVisited6
    {
        get { return sceneVisited6; }
        set { sceneVisited6 = value; }
    }

}
