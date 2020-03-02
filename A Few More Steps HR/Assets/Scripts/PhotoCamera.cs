//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PhotoCamera : MonoBehaviour
//{
    
//    public static int photoIndex;
//    private static PhotoCamera instance;
//    public GameObject PhotoAlbum;
//    private Camera photoCam;
       
//    private bool takeScreenshotOnNextFrame;
//    private void Start()
//    {
//        instance = this;
//        photoCam = GetComponent<Camera>();
//        photoCam.fieldOfView = 45;
//    }

//    private void Update()
//    {

//        if (Input.GetKey(KeyCode.E) && GetComponent<Camera>().fieldOfView < 60)
//        {
//            photoCam.fieldOfView += 1;
//        }

//        else if (Input.GetKey(KeyCode.Q) && GetComponent<Camera>().fieldOfView > 30)
//        {
//            photoCam.fieldOfView -= 1;
//        }
//    }

//    private void OnPostRender()
//    {
        
//        if (takeScreenshotOnNextFrame)
//        {
//            takeScreenshotOnNextFrame = false;
//            RenderTexture renterTex = photoCam.targetTexture;
//            Texture2D renderResult = new Texture2D(renterTex.width, renterTex.height, TextureFormat.RGB565, false);
//            Rect rect = new Rect(0, 0, renterTex.width, renterTex.height);
//            renderResult.ReadPixels(rect, 0, 0);

//            // encodes render2d into png
//            byte[] byteArray = renderResult.EncodeToPNG();
//            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraShot " + photoIndex  +".png", byteArray);
//            Debug.Log("Saved pic to " + Application.dataPath);
//            PhotoAlbum.GetComponent<GetPhotos>().LoadNewSprite(Application.dataPath + "/CameraShot " + photoIndex + ".png");

//            // clean up
//            RenderTexture.ReleaseTemporary(renterTex);
//            photoCam.targetTexture = null;
//            photoIndex++;
//        }
         
//    }
//    private void TakeScreenshot(int width , int height)
//    {
//        photoCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
//        takeScreenshotOnNextFrame = true;
//    }
//    public static void TakeScreenShotStatic (int width , int height)
//    {
//        instance.TakeScreenshot(width, height);
//    }
//}

 
