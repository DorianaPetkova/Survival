using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class KitchenStove : MonoBehaviour
{
    public GameObject colliderStove;
    public GameObject textfire;
    public static bool stove { get; set; } = false;
  
    void Start()
    {
        textfire.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("colliderStove"))
            {
                stove = true;
            }
        }

    }

    // Update is called once per frame
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
}
