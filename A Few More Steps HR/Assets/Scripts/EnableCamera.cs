using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCamera : MonoBehaviour
{
    public Camera camera;
    public GameObject photoAlbum;
    public Camera mainCamera;
    [SerializeField]
    private int camToggle;
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        camToggle = 1;
        photoAlbum = GameObject.Find("PhotoAlbum");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !GetPhotos.inInventory)
        {
            camToggle++;
            CameraToggle();

        }
       
        // take photos
        //if (camToggle == 0 && !GetPhotos.inInventory)
        //{
        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Debug.Log("ScreenShot");
        //       // PhotoCamera.TakeScreenShotStatic(800, 800);
        //    }

        //}
    }
    void CameraToggle()
    {
        if (camToggle > 1)
        {
            //turns on camera
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.transform.position = mainCamera.transform.position;

            gameManager.GetComponent<GameManager>().StopMovement();

            mainCamera.gameObject.SetActive(false);
            camToggle = 0;
          
        }
        else
        {
            // turns off camera
            transform.GetChild(0).gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            // PlayerMovement.stopMovement = false;
            //   cameraOn = false;          
            //Enables players controls and camera
            gameManager.GetComponent<GameManager>().ResumePlayerControls();

        }
    }
}
