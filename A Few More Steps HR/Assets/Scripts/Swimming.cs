using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Swimming : MonoBehaviour
{
    PlayerMovement movement;
    private Vector3 moveDir = Vector3.zero;
    private GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main Camera");

        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (PlayerMovement.isSwimming)
        {
            SwimMovement();
        }
    }
    void SwimMovement()
    {
       if(moveDir.x > 0)
        {
            moveDir.y = 1f;
        }
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDir = mainCam.transform.TransformDirection(moveDir);  
        if(Input.GetKey(KeyCode.Space))
        {
            moveDir.y += 0.55f;
        }
        moveDir.y -= 0.10f;      
        movement.controller.Move(moveDir * 4 * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("swimming");
            PlayerMovement.isSwimming = true;
            PlayerMovement.stopMovement = true;

            //EnableCamera.stopTakingPhotos = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("ExitWater");
            PlayerMovement.isSwimming = false;
            PlayerMovement.stopMovement = false;
           // EnableCamera.stopTakingPhotos = false;

        }
    }
}
