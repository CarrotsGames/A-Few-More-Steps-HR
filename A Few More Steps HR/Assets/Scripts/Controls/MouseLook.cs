using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity;
    public Transform playerBody;
    public GameObject player;
    float rotateX = 0f;
    public static bool canLook;
    private void Start()
    {
        canLook = true;
        player = GameObject.Find("Player");     
       
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (canLook)
        {
            //NOTE: sensitivity may change depending on monitors due to Time
            float mouseX = Input.GetAxis("Mouse X") * sensitivity ;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity ;

            rotateX -= mouseY;             //up  down
            rotateX = Mathf.Clamp(rotateX, -60, 60);
            // turns player model based on mouse x
            transform.localRotation = Quaternion.Euler(rotateX, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
  
}
