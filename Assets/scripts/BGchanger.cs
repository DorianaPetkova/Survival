using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGchanger : MonoBehaviour
{
    //array for background sprites
    public Sprite[] backgrounds;
    public Image backgroundImage;
    public float time;

    void Start()
    {
        //changing background
        InvokeRepeating("ChangeBackground", 0f, time);
    }

    void ChangeBackground()
    {
        int randomIndex = Random.Range(0, backgrounds.Length);
        backgroundImage.sprite = backgrounds[randomIndex];
    }
}
