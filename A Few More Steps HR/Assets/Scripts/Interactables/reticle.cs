using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class reticle : MonoBehaviour
{
 
    public static Image reticleImage;
    private void Start()
    {
        Debug.Log(this.gameObject);
        reticleImage = GetComponent<Image>();
      
    }
    public static void HighliteObject()
    {
        reticleImage.color = Color.white;
        //reticleSprite.color = Color.white;
    }
   public static void disableHighlite()
    {
     //   reticleImage.color = Color.gray;
         reticleImage.color = Color.gray;
    }
    public void DisableReticle()
    {
        //   reticleImage.color = Color.gray;
        this.gameObject.SetActive(false);
    }
    public void EnableReticle()
    {
        //   reticleImage.color = Color.gray;
        this.gameObject.SetActive(true);
    }
    void deniedReticle()
    {
        // put a sign saying you can open/pick up this yet
    }
}
