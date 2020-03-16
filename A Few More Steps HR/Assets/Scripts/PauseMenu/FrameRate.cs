using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{

  //  public int[] frameRate = { 30, 45, 60 ,144 };
    public int frameRate;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
