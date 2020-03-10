using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool cameraOn;
    public GameObject player;
    public GameObject mainCam;
    private void Update()
    {
        if (cameraOn)
        {
            PlayerMovement.stopMovement = false;
        }
    }
    public void StopPlayerControls()
    {
        player.GetComponent<CharacterController>().enabled = false;
        MouseLook.canLook = false;
        Cursor.lockState = CursorLockMode.None;

    }
    public void ResumePlayerControls()
    {
        player.GetComponent<CharacterController>().enabled = true;
        MouseLook.canLook = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void StopMovement()
    {
        player.GetComponent<CharacterController>().enabled = false;
    }
   
}
