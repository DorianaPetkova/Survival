using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGchanger : MonoBehaviour
{
    /*public Sprite[] sprites;
    public Image img;
    
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, sprites.Length);
        img.sprite = sprites[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public Sprite[] backgrounds; // Add your background sprites to this array
    public Image backgroundImage; // Reference to the Image component of the background
    public float time;

    void Start()
    {
        InvokeRepeating("ChangeBackground", 0f, time); // Change background every 10 seconds
    }

    void ChangeBackground()
    {
        int randomIndex = Random.Range(0, backgrounds.Length);
        backgroundImage.sprite = backgrounds[randomIndex];
    }
}
