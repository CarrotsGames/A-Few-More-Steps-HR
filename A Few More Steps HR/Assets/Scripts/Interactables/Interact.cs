using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script handles any interactions that arnt items
public class Interact : MonoBehaviour
{
    [Header("Match with door anim time")]
    public float doorOpenTime = 1;
    public GameObject armAnim;
    [HideInInspector]
    public GameObject animationManager;
   
    private bool doorCooldown;
    private float doorOpenTimeStore;
    private GameObject cutsceneFade;
    private AnimationManager animationManagerScript;
    private void Start()
    {
        doorCooldown = true;
        doorOpenTimeStore = doorOpenTime;
        animationManager = GameObject.Find("AnimationManager");
        animationManagerScript = animationManager.GetComponent<AnimationManager>();
        if (armAnim == null)
        {
            Debug.LogError("ARM ANIM /FINAL DOOR CAM /FINALDOOR GO NOT ADDED TO INTERACT SCRIPT ON CMCAMERA");
        }
        cutsceneFade = GameObject.Find("ScreenFade");
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

            InteractingWith(hit.transform.gameObject);

        }
        else
        {
            reticle.disableHighlite();
        }
    }
    void InteractingWith(GameObject interactedItem)
    {
       switch (interactedItem.tag)
        {
            case "Book":
                reticle.HighliteObject();
                if (Input.GetKey(KeyCode.E))
                {
                    interactedItem.GetComponent<Notes>().ReadNote();
                }
                break;
            case "Handle":
                reticle.HighliteObject();

                if (Input.GetKeyDown(KeyCode.E) && !doorCooldown)
                {
                    doorCooldown = true;
                    // when door is opened
                    if (interactedItem.GetComponentInParent<Animator>().GetBool("OpenDoor"))
                    {
                        //  hit.transform.gameObject.GetComponentInParent<Animator>().SetBool("OpenDoor", false);
                    }
                    // when door is closed
                    else
                    {
                        armAnim.SetActive(true);
                        StartCoroutine(OpeningDoor());
                        interactedItem.GetComponentInParent<Animator>().SetBool("OpenDoor", true);

                    }
                }
                break;
            case "BabyDoorHandle":
                reticle.HighliteObject();

                if (Input.GetKeyDown(KeyCode.E) && !doorCooldown)
                {
                    animationManagerScript.AnimationName("BabiesDoorAnim", interactedItem);
                }
                break;
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
