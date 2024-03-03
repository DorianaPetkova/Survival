using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteAlways]
public class targetAspectRatio : MonoBehaviour
{

    [SerializeField] private Camera cam;

    private readonly Vector2 aspectRatio = new(16, 9);
    private readonly Vector2 rectCenter = new(0.5f, 0.5f);

    private Vector2 lastResolution;

    private void OnValidate()
    {
        cam ??= GetComponent<Camera>();
    }

    public void LateUpdate()
    {
        var currentScreenResolution = new Vector2(Screen.width, Screen.height);

        // dont run the calculations if the resolutions hasnt changed
        if (lastResolution != currentScreenResolution)
        {
            CalculateCameraRect(currentScreenResolution);
        }

        lastResolution = currentScreenResolution;
    }

    private void CalculateCameraRect(Vector2 currentScreenResolution)
    {
        var normalizedAspectRatio = aspectRatio / currentScreenResolution;
        var size = normalizedAspectRatio / Mathf.Max(normalizedAspectRatio.x, normalizedAspectRatio.y);
        cam.rect = new Rect(default, size) { center = rectCenter };
    }
}
