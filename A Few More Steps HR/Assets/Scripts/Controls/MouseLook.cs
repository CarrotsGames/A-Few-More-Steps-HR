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
    public static float globalSensitivity;
    private void Start()
    {
        canLook = true;
        player = GameObject.Find("Player");
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        if(sensitivity == 0)
        {
            sensitivity = 2;
            PlayerPrefs.SetFloat("Sensitivity", sensitivity);

        }
        globalSensitivity = sensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (canLook)
        {
            sensitivity = globalSensitivity;
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
