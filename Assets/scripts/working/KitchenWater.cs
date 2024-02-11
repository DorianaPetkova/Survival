using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class KitchenWater : MonoBehaviour
{
    public GameObject textwater;
    public GameObject colliderWater;
   
    public static bool water { get; set; } = false;
    void Start()
    {
        textwater.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("colliderWater"))
            {
                textwater.SetActive(true);
                water = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideText1()
    {
        if (textwater != null)
        {
            textwater.SetActive(false);


        }
        GameController.Instance.SceneVisited4 = true;

    }
}
