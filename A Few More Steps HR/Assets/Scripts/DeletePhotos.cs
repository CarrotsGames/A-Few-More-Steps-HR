using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeletePhotos : MonoBehaviour
{
    //public int photoIndex;
    //public GameObject getPhotos;
    //private void Start()
    //{
    //    // LOAD NEW TEX
    //   // getPhotos.GetComponent<GetPhotos>().LoadNewSprite(Application.dataPath + "/CameraShot " + photoIndex + ".png");
        
    //}
    public void DeletePhoto(int index)
    {
        
        // CLEAR IMAGE (Turn down alpha) 
        Color alpha = GetComponent<Image>().color;
        alpha.a = 0f;
        GetComponent<Image>().color = alpha;
        // REMOVE PHOTO TAG
        this.gameObject.tag = "Untagged";
      //  PhotoCamera.photoIndex = index;
    }
}
