using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteMask spriteMaskM;
    public SpriteMask spriteMaskF;
    void Start()
    {
        if (spriteMaskM != null)
            spriteMaskM.enabled = false;
        if (spriteMaskF != null)
            spriteMaskF.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteMaskM != null && Ebutton.clue4)
            spriteMaskM.enabled = true;
        if (spriteMaskF != null && Ebutton.clue4)
            spriteMaskF.enabled = true;
    }
}
