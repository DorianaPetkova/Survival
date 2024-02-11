using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMoveNext : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject entrance;
    public GameObject exit;
    public GameObject thirdDoor;
    [SerializeField] public SceneInfo sceneinfo;
    public float offsetX = 0f; public float offsetY = 0f;
    private Rigidbody2D body;
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!mainMenu.clue1 && SceneManager.GetActiveScene().buildIndex == 1)
        {

            body.position = new Vector3(-114f, 25f, 0f);
            Debug.Log("should work");
        }
    }
    void Start()
    {

        int sceneBuildIndex = LevelMove.sceneBuildIndexPass;
        int previousSceneBuildIndex = LevelMove.sceneBuildIndexPass;
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the previous scene was the level scene and the current scene is city scene 1
        if (previousSceneBuildIndex == 26 && currentSceneBuildIndex == 1)
        {
            // Set specific coordinates for city scene 1
            Vector3 startingPosition = new Vector3(-114f, 25f, 0f);
            body.position = startingPosition;
            Debug.Log($" CHECK FIRST SCENE{body.position}");
        }
        else
        {
            // Coming from entrance
            if (sceneinfo.NextScene)
            {
                if (entrance != null)
                {
                    Vector3 startingPosition = entrance.transform.position;
                    switch (sceneBuildIndex)
                    {
                        case 7:
                            startingPosition += new Vector3((offsetX - 55), (offsetY + 125), 0f);
                            break;
                        case 8:
                            startingPosition += new Vector3((offsetX + 40), (offsetY + 40), 0f);
                            break;
                        case 9:
                        case 10:
                            startingPosition += new Vector3((offsetX - 30), +(offsetY + 205), 0f);
                            break;
                        case 11:
                            startingPosition += new Vector3((-offsetX), +(offsetY + 40), 0f);
                            break;
                        case 15:
                        case 16:
                        case 18:
                        case 20:
                        case 22:
                            startingPosition += new Vector3((offsetX - 75), -(offsetY + 40), 0f);
                            break;
                        case 14:
                        case 17:
                        case 19:
                        case 21:
                        case 23:
                            startingPosition += new Vector3((offsetX - 60), -(offsetY + 30), 0f);
                            break;
                        case 12:
                            startingPosition += new Vector3((offsetX + 70), +(offsetY + 200), 0f);
                            break;
                        case 13:
                            startingPosition += new Vector3((offsetX - 40), (offsetY + 135), 0f);
                            break;
                        case 28:
                            startingPosition += new Vector3((offsetX + 100), -(offsetY + 60), 0f);
                            break;

                        default:
                            startingPosition += new Vector3(offsetX, offsetY, 0f);
                            Debug.Log("the other default");
                            break;
                    }
                    body.position = startingPosition;
                }
            }
            else if (sceneinfo.isThirdDoor)
            {
                if (sceneBuildIndex == 12)
                {
                    Vector3 startingPosition = thirdDoor.transform.position + new Vector3((offsetX + 10), -(offsetY + 70), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 14)
                {
                    Vector3 startingPosition = exit.transform.position + new Vector3((offsetX - 30), -(offsetY + 80), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 7)
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3((offsetX), (offsetY - 50), 0f);
                    body.position = startingPosition;
                }
            }
            else
            {
                if (exit != null)
                {
                    Vector3 startingPosition = exit.transform.position;
                    switch (sceneBuildIndex)
                    {
                        case 5:
                            startingPosition += new Vector3((offsetX - 70), (offsetY - 155), 0f);
                            break;
                        case 6:
                            startingPosition -= new Vector3((offsetX - 80), (offsetY + 30), 0f);
                            break;
                        case 7:
                            startingPosition -= new Vector3((offsetX), (offsetY - 50), 0f);
                            break;
                        case 8:
                            startingPosition -= new Vector3((offsetX + 10), -(offsetY + 40), 0f);
                            break;
                        case 9:
                        case 10:
                            startingPosition += new Vector3((offsetX - 20), (offsetY - 230), 0f);
                            break;
                        case 11:
                            startingPosition += new Vector3((offsetX + 50), +(offsetY + 30), 0f);
                            break;
                        case 15:
                        case 16:
                        case 18:
                        case 20:
                        case 22:
                            startingPosition -= new Vector3((offsetX - 80), +(offsetY + 30), 0f);
                            break;
                        case 14:
                        case 17:
                        case 19:
                        case 21:
                        case 23:
                            startingPosition += new Vector3((offsetX - 55), -(offsetY + 50), 0f);
                            break;
                        case 12:
                            startingPosition += new Vector3((offsetX), -(offsetY + 75), 0f);
                            break;
                        default:
                            startingPosition -= new Vector3(offsetX, -offsetY, 0f);
                            Debug.Log("defaults at fault");
                            break;
                    }
                    body.position = startingPosition;
                }
            }
        }
    }


}
