using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Shake : MonoBehaviour
{
    public static float shakeTimeRemaining = 11;
    private float shakePower;
    private float shakeFadeTime;
    private float shakeRotation;
    public float rotationMultiplier = 7;
    public static bool isShaking { get; private set; } = false;
    private float delayTimer = 2f; // Delay before starting the shake
    private float currentDelay;
    public GameObject rectangle;


    void Update()
    {

        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }
        else
        {
            // If the delay is over, and AudioManager.quake is true, start shaking
            if (AudioManager.quake && !isShaking)
            {
                StartShake(11f, 1f);
                isShaking = true;// Set the flag to true when shaking starts

            }

        }
        if (isShaking && shakeTimeRemaining <= 0)
        {
            // Shaking is done, activate the rectangle
            rectangle.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining = Mathf.Max(0f, shakeTimeRemaining - Time.deltaTime);
            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(x, y, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }
    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
        shakeFadeTime = power / length;
        shakeRotation = power * rotationMultiplier;
    }

    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        currentDelay = delayTimer;
        rectangle.SetActive(false);
    }

    // Update is called once per frame



}
