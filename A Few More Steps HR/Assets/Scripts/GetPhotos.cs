using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetPhotos : MonoBehaviour
{
    private GameObject mainCam;
    private GameObject photoCam;
    private bool nullPhoto;
    int toggle;
    List<Texture2D> photos;
    private GameObject gameManager;
    public static bool inInventory;
    private void Start()
    {   
        gameManager = GameObject.Find("GameManager");

        //mainCam = GameObject.Find("CMMainCamera");
        //photoCam = GameObject.Find("PhotoCam");
        //photos = new List<Texture2D>();
        toggle = 0;
        // turn off galery
        transform.GetChild(0).gameObject.SetActive(false);
        inInventory = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !PlayerMovement.isSwimming)
         {
            toggle++;
            TogglePics();
        }
       
    }
    void TogglePics()
    {
        if (toggle > 1)
        {         
            // turn off galery
            transform.GetChild(0).gameObject.SetActive(false);
            toggle = 0;
            gameManager.GetComponent<GameManager>().ResumePlayerControls();
            inInventory = false;

        }
        else
        {
               
            // turn on gallery
            transform.GetChild(0).gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().StopPlayerControls();
            inInventory = true;
        }
    }
    //public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f)
    //{
     
    //    Sprite newSprite;
    //    // loads new texture made from camera
    //    Texture2D a = LoadTexture(FilePath);
    //    CheckForPhoto();
    //    // creates sprite of texture
    //    newSprite = Sprite.Create(a, new Rect(0, 0, 800, 800), new Vector2(0, 0), 1);
    //    GameObject gallery = transform.GetChild(0).gameObject;
    //    if (nullPhoto)
    //    {
    //        nullPhoto = false;    
    //        return null;
    //    }
    //    // adds it to the sprite image
    //    gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().sprite = newSprite;
    //     Color alpha = gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().color;
    //     alpha.a = 1f;
    //     gallery.transform.GetChild(PhotoCamera.photoIndex).GetComponent<Image>().color = alpha;
      
    //    return newSprite;

    //}
    //void CheckForPhoto()
    //{
    //    GameObject gallery = transform.GetChild(0).gameObject;
            
    //    for (int i = 0; i < gallery.transform.childCount; i++)
    //    {
    //        // checks for an open slot to put the photo in
    //        // to avoid overrighting a photo if one is deleted
    //        if(gallery.transform.GetChild(i).tag != "Photo")
    //        {
    //            PhotoCamera.photoIndex = i;
    //            gallery.transform.GetChild(i).tag = "Photo";
    //            return;
    //        }
    //    }


    //}
    //public Texture2D LoadTexture(string FilePath)
    //{

    //    // Load a PNG or JPG file from disk to a Texture2D
    //    // Returns null if load fails

    //    Texture2D Tex2D;
    //    byte[] FileData;

    //    if (System.IO.File.Exists(FilePath))
    //    {
    //        // Reads in finished png file
    //        FileData = System.IO.File.ReadAllBytes(FilePath);
    //        // creates empty texture to write png to
    //        Tex2D = new Texture2D(2, 2);          
    //        // Load the imagedata into the texture (size is set automatically)
    //        if (Tex2D.LoadImage(FileData))          
    //            return Tex2D;                
    //    }
    //    nullPhoto = true;
    //    return null;                     
    //}


}
