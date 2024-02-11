
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{
    //information for levelmovenext, coordinate character position
    public bool NextScene = true;
    public bool isThirdDoor = false;
    void OnEnable()
    {
        NextScene = true;
        isThirdDoor = false;
    }
}
