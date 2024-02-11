using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedLevel : MonoBehaviour
{
    // for activating the right colliders
    public void OnEarthquakeButtonClicked()
    {
        GameController.Instance.selectedLevel = "Earthquake";
    }
    public void OnFireHazzardButtonClicked()
    {
        GameController.Instance.selectedLevel = "FireHazzard";
    }
}
