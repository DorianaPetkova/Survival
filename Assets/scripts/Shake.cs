using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shake : MonoBehaviour
{

    private static Shake instance;

    // making sure only one instance exists
    public static Shake Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Shake>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(Shake).Name;
                    instance = obj.AddComponent<Shake>();
                }
            }
            return instance;
        }
    }
    public GameObject colliderExit;
    public GameObject colliderEntrance;
    public GameObject colliderDoor;

    private float shakePower;
    private float shakeFadeTime;
    private float shakeRotation;
    public static float shakeTimeRemaining = 11;
    public static bool shook { get; set; } = false;
    private float rotationMultiplier = 7;
    public static bool isShaking { get; set; } = false;
    public static bool clue3 { get; set; } = false;
    // Delay before starting the shake
    private float delayTimer = 2f;
    private float currentDelay;
    public GameObject textCanvas;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        currentDelay = delayTimer;
        if (textCanvas != null)
            textCanvas.SetActive(false);
        if (colliderExit != null)
            colliderExit.SetActive(false);
        if (colliderDoor != null)
            colliderDoor.SetActive(false);
        if (colliderEntrance != null)
            colliderEntrance.SetActive(false);
    }
    void Update()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }
        else
        {
            // start shaking
            if (AudioManager.quake && !isShaking)
            {
                StartShake(11f, 1f);
                isShaking = true;

            }

        }
        if (isShaking && shakeTimeRemaining <= 0)
        {
            // shaking done, activate the rectangle
            if (colliderExit != null && Ebutton.gotit)
                colliderExit.SetActive(true);
            if (colliderDoor != null)
                colliderDoor.SetActive(true);
            if (colliderEntrance != null)
                colliderEntrance.SetActive(true);

            if (!GameController.Instance.SceneVisited2 && textCanvas != null)
            {
                textCanvas.SetActive(true);

            }
            else if (GameController.Instance.SceneVisited2 && textCanvas != null)
            {
                textCanvas.SetActive(false);
            }
        }
    }
    private void LateUpdate()
    {
        if (shook && shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(x, y, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
        }
    }

    // start the shake
    public void StartShake(float length, float power)
    {
        if (!shook)
        {
            shakeTimeRemaining = length;
            shakePower = power;
            shakeFadeTime = power / length;
            shakeRotation = power * rotationMultiplier;
            shook = true;

        }
    }


    public void StopShake()
    {
        shook = false;

    }
    public void ResumeShake()
    {
        if (!shook)
        {
            shook = true;

        }
    }
    public void HideText()
    {
        if (textCanvas != null)
        {
            
            textCanvas.SetActive(false);
            clue3 = true;
            

        }
        GameController.Instance.SceneVisited2 = true;
    }
}
