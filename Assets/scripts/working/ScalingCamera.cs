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
        // get the y of the parent
        float yPos = transform.position.y;

        // keep the y in the specific range
        yPos = Mathf.Clamp(yPos, minY, maxY);

        // calculate
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minY, maxY, yPos));

        // apply
        transform.localScale = new Vector3(scale, scale, 1f);
    }

}
