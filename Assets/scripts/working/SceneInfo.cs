
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{
    public bool NextScene = true;
    public bool isThirdDoor = false; // Add this line
    void OnEnable()
    {
        NextScene = true;
        isThirdDoor = false;

    }

}
