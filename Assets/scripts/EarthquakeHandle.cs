using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeHandle : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to AudioManager
    public GameObject rectangle;
    void Start()
    {

        if (rectangle != null)
        {
            rectangle.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Shake.isShaking)
        {
            // Do something when quake is true
            rectangle.SetActive(true);
        }
        else
            rectangle.SetActive(false);
    }
}
