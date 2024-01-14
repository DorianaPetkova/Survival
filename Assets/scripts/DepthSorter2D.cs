using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSorter2D : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;

    void Update()
    {
        if (character == null)
        {
            Debug.LogError("Character GameObject is not assigned.");
            return;
        }

        SpriteRenderer characterRenderer = character.GetComponent<SpriteRenderer>();
        SpriteRenderer objectRenderer = GetComponent<SpriteRenderer>();

        if (character.transform.localScale.y > transform.localScale.y)
        {
            // If character is above the object, set sorting order behind
            characterRenderer.sortingOrder = objectRenderer.sortingOrder - 1;
        }
        else
        {
            // If character is below the object, set sorting order in front
            characterRenderer.sortingOrder = objectRenderer.sortingOrder + 1;
        }
    }
}
