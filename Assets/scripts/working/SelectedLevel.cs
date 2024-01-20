using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEarthquakeButtonClicked()
    {
        GameController.Instance.selectedLevel = "Earthquake";
    }
    public void OnFireHazzardButtonClicked()
    {
        GameController.Instance.selectedLevel = "FireHazzard";
    }
}
