﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
 
    // Update is called once per frame
    void Update()
    {
        // turns off gameobject and disabled insepct cam
        if (CloseInspect.disableItem)
        {
            this.transform.parent.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            CloseInspect.disableItem = false;
        }
        // rotated item with mouse
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), - Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 100);
        }
        // zooms forward
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && transform.GetComponentInParent<Camera>().fieldOfView > 30)
        {
            transform.GetComponentInParent<Camera>().fieldOfView -= 1;
        }
        // zooms  back
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && transform.GetComponentInParent<Camera>().fieldOfView < 80 ) 
        {
            transform.GetComponentInParent<Camera>().fieldOfView += 1;
        }
    }
}
