using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTexSetup : MonoBehaviour
{
    public Camera camB;
    public Material camMatB;
    // Start is called before the first frame update
    void Start()
    {
        if (camB.targetTexture != null)
        {
            camB.targetTexture.Release();
        }

        camB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camMatB.mainTexture = camB.targetTexture;

    }
 
}
