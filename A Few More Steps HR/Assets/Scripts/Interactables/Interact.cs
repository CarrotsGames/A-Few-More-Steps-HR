using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script handles any interactions that arnt items
public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
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
                    if (Input.GetKey(KeyCode.E))
                    {
                        reticle.HighliteObject();
                        // when door is opened
                        if(hit.transform.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("OpenDoor"))                      
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
