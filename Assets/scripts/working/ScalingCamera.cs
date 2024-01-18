using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingCamera : MonoBehaviour
{

    // Start is called before the first frame update
    public float minY = -2f;
    public float maxY = 5f;
    public float minScale = 1.2f;
    public float maxScale = 0.7f;
    public float manualScale = 500.0f;

    private void Update()
    {
        // Get the Y position of the parent (this GameObject)
        float yPos = transform.position.y;

        // Clamp the Y position within the specified range
        yPos = Mathf.Clamp(yPos, minY, maxY);

        // Calculate the scale based on the clamped Y position
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minY, maxY, yPos));

        // Apply the scale to the parent GameObject
        transform.localScale = new Vector3(scale, scale, 1f);
    }

}
