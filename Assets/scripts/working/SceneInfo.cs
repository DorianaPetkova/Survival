
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{
    public bool NextScene = true;
    public bool ThirdDoor = false;
    public bool CheckForEButton = false;
    void OnEnable()
    {
        NextScene = true;
    }

}
