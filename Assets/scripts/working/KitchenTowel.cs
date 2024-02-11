using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class KitchenTowel : MonoBehaviour
{
    public GameObject textstove;
    public GameObject colliderTowel;

    public static bool fire { get; set; } = false;
    void Start()
    {
        textstove.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("colliderTowel"))
            {
                textstove.SetActive(true);
                fire = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

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
