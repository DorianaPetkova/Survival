using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoveNext : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject entrance;
    public GameObject exit;
    public GameObject thirddoor;
    [SerializeField] public SceneInfo sceneinfo;
    public float offsetX = 0f; public float offsetY = 0f;


    private Rigidbody2D body;
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        int sceneBuildIndex = LevelMove.sceneBuildIndexPass;
        if (sceneinfo.NextScene) // Coming from entrance
        {
            if (entrance != null)
            {
                if (sceneBuildIndex == 7)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((offsetX - 55), (offsetY + 125), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 8)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((offsetX + 40), (offsetY + 40), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 10 || sceneBuildIndex == 9)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((offsetX - 30), +(offsetY + 205), 0f);
                    body.position = startingPosition;

                }
                else if (sceneBuildIndex == 11)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((-offsetX), +(offsetY + 40), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 15 || sceneBuildIndex == 16 || sceneBuildIndex == 18 || sceneBuildIndex == 20 || sceneBuildIndex == 22)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((offsetX - 75), -(offsetY + 40), 0f);
                    body.position = startingPosition;
                    Debug.Log($"{body.position}");
                    Debug.Log($"{entrance.transform.position}");
                    Debug.Log($"{offsetX - 60} {offsetY}");
                }
                else if (sceneBuildIndex == 14 || sceneBuildIndex == 17 || sceneBuildIndex == 19 || sceneBuildIndex == 21 || sceneBuildIndex == 23)
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3((offsetX - 60), -(offsetY + 30), 0f);
                    body.position = startingPosition;
                }
                else
                {
                    Vector3 startingPosition = entrance.transform.position + new Vector3(offsetX, offsetY, 0f);
                    body.position = startingPosition;
                    Debug.Log($"ON THE LEFT SIDE");
                    Debug.Log($"{sceneBuildIndex}");

                }
                //Debug.Log($"wrong exit: {body.position}");
            }
        }
        else if (sceneinfo.ThirdDoor)
        {
            if (thirddoor != null)
            {
                Vector3 startingPosition = thirddoor.transform.position + new Vector3(offsetX - 80, offsetY + 90, 0f);
                body.position = startingPosition;
            }
        }
        else // Coming from exit
        {
            if (exit != null)
            {
                Debug.Log($"ON THE RIGHT SIDE");
                //Debug.Log($"{LevelMove.sceneBuildIndexPass}");
                if (sceneBuildIndex == 5)
                {
                    Vector3 startingPosition = exit.transform.position + new Vector3((offsetX - 70), (offsetY - 155), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 6)
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3((offsetX - 80), (offsetY + 30), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 7)
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3((offsetX - 20), (offsetY - 55), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 8)
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3((offsetX + 10), -(offsetY + 40), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 9 || sceneBuildIndex == 10)
                {

                    Vector3 startingPosition = exit.transform.position + new Vector3((offsetX - 20), (offsetY - 230), 0f);
                    body.position = startingPosition;

                }
                else if (sceneBuildIndex == 11)
                {
                    Vector3 startingPosition = exit.transform.position + new Vector3((offsetX + 15), +(offsetY + 30), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 15 || sceneBuildIndex == 16 || sceneBuildIndex == 18 || sceneBuildIndex == 20 || sceneBuildIndex == 22)
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3((offsetX - 80), +(offsetY + 30), 0f);
                    body.position = startingPosition;
                }
                else if (sceneBuildIndex == 14 || sceneBuildIndex == 17 || sceneBuildIndex == 19 || sceneBuildIndex == 21 || sceneBuildIndex == 23)
                {
                    Vector3 startingPosition = exit.transform.position + new Vector3((offsetX - 55), -(offsetY + 50), 0f);
                    body.position = startingPosition;
                    Debug.Log($"Exit position: {body.position}");
                    Debug.Log($"Collider position: {entrance.transform.position}");
                    Debug.Log($"offset: {offsetX - 40} {offsetY}");

                }
                else
                {
                    Vector3 startingPosition = exit.transform.position - new Vector3(offsetX, -offsetY, 0f);
                    body.position = startingPosition;
                }

            }
        }
    }


}
