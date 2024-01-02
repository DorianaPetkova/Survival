using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGchanger : MonoBehaviour
{
    public Sprite[] sprites;
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
        
    }
}
