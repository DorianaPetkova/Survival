using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Light2D mylight;

    private int frames = 0;

    [SerializeField] private int framesPerRandomize;

    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % framesPerRandomize == 0)
        {
            RandomizeIntensity();
        }
    }

    void RandomizeIntensity()
    {
        // Create an instance of the Random class
        System.Random random = new System.Random();


        float randomValue = (float)(random.NextDouble() * (maxValue - minValue) + minValue);

        mylight.intensity = randomValue;
    }
}
