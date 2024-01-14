using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector2 lastPlayerPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SceneTransition"))
        {
            lastPlayerPosition = transform.position;
        }
    }
}
