using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPhotos : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
         for (int i = 0; i < 8; i++)
        {
            GetComponent<GetPhotos>().LoadNewSprite(Application.dataPath + "/CameraShot " + i + ".png");
            
        }

    }


}
