using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script handles any interactions that arnt items
public class Interact : MonoBehaviour
{
    [Header("Match with door anim time")]
    public float doorOpenTime = 1;
    private bool doorCooldown;
    private float doorOpenTimeStore;
    private void Start()
    {
        doorCooldown = true;
        doorOpenTimeStore = doorOpenTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(doorCooldown)
        {
            doorOpenTime -= Time.deltaTime;
            if(doorOpenTime <= 0)
            {
                Debug.Log("CanUseDoorAgain");
                doorCooldown = false;
                doorOpenTime = doorOpenTimeStore;
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            switch(hit.transform.gameObject.tag)
            { 
                case "Book":
                    reticle.HighliteObject();
                    if (Input.GetKey(KeyCode.E))
                    {
                        hit.transform.gameObject.GetComponent<Notes>().ReadNote();
                    }
                    break;
                case "Handle":
                    reticle.HighliteObject();
                    // when door is opened
                    if (Input.GetKeyDown(KeyCode.E) && !doorCooldown)
                    {
                        doorCooldown = true;
                       
                        if(hit.transform.gameObject.GetComponentInParent<Animator>().GetBool("OpenDoor"))                      
                        {                           
                              hit.transform.gameObject.GetComponentInParent<Animator>().SetBool("OpenDoor", false);                                     
                        }
                        // when door is closed
                        else
                        {
                            hit.transform.gameObject.GetComponentInParent<Animator>().SetBool("OpenDoor", true);
                        }
                    }
                    break;

            }
           
             

        }
        else
        {
            reticle.disableHighlite();
        }
    }
}
