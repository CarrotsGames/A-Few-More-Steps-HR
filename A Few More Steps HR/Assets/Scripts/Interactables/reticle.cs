using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reticle : MonoBehaviour
{
    public static Image reticleImage;
    private void Start()
    {
        reticleImage = GetComponent<Image>();
    }
    public static void HighliteObject()
    {
        reticleImage.color = Color.white;
     //   reticleSprite.color = Color.white;
    }
   public static void disableHighlite()
    {
        reticleImage.color = Color.gray;
        // reticleImage.color = Color.gray;
    }
    void deniedReticle()
    {
        // put a sign saying you can open/pick up this yet
    }
}
