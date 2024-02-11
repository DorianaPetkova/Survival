using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class kitchen : MonoBehaviour
{
    
    public GameObject textfire;
    public GameObject textwater;
    public GameObject textstove;
    public GameObject spriteFire;
    public GameObject spriteTowel;
    public GameObject colliderTowel;
    public GameObject colliderWater;
    public GameObject colliderStove;
    
    public static bool water { get; set; } = false;
    public static bool fire { get; set; } = false;
    public static bool stove { get; set; } = false;

    void Start()
    {
        textfire.SetActive(true);
        textwater.SetActive(false);
        textstove.SetActive(false);
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("colliderWater"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                textwater.SetActive(true);
                water = true;
            }
        }
        if (other.CompareTag("colliderTowel"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                textstove.SetActive(true);
                fire = true;
                


            }
        }
        if (other.CompareTag("colliderStove"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                stove = true;
            }
        }
    }
   

    void Update()
    {
        
    }
    
   

    public void HideText()
    {
        if (textfire != null)
        {
            textfire.SetActive(false);


        }
        GameController.Instance.SceneVisited4 = true;

    }
    public void HideText1()
    {
        if (textwater != null)
        {
            textwater.SetActive(false);
            

        }
        GameController.Instance.SceneVisited4 = true;

    }
    public void HideText2()
    {
        if (textstove != null)
        {
            textstove.SetActive(false);


        }
        GameController.Instance.SceneVisited4 = true;

    }
}
