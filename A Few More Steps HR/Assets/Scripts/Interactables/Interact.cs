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
    public GameObject armAnim;

    private void Start()
    {
        doorCooldown = true;
        doorOpenTimeStore = doorOpenTime;
        if(armAnim == null)
        {
            Debug.LogError("ARM ANIM NOT ADDED TO INTERACT SCRIPT ON CMCAMERA");
        }
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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
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
            
                    if (Input.GetKeyDown(KeyCode.E) && !doorCooldown)
                    {
                        doorCooldown = true;
                       // when door is opened
                        if(hit.transform.gameObject.GetComponentInParent<Animator>().GetBool("OpenDoor"))                      
                        {                           
                          //  hit.transform.gameObject.GetComponentInParent<Animator>().SetBool("OpenDoor", false);
                        }
                        // when door is closed
                        else
                        {
                            armAnim.SetActive(true);
                            StartCoroutine(OpeningDoor());
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
    IEnumerator OpeningDoor( )
    {
        armAnim.GetComponent<Animator>().SetBool("OpenDoor", true);
        yield return new WaitForSeconds(1.5f);
        armAnim.GetComponent<Animator>().SetBool("OpenDoor", false);
        // adds item progress to manager  
        yield return new WaitForSeconds(2.5f);
        // disables arms and collected gameobject
        armAnim.SetActive(false);
        //movement resumed
        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;

    }
}
