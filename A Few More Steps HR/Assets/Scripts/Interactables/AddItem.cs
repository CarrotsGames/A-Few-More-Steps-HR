using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject pickUpArm;
    public GameObject hand;
    public float distance;
    [Header("Collected Items")]
    public List<GameObject> items;
    public LayerMask mask;
    private GameObject inventory;
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    GameObject hitGameobject;
    
    private void Start()
    {
        pickUpArm.SetActive(false);

        if (pickUpArm == null || hand == null)
        {
            Debug.LogError("ARM OR ITEMPICKUPPOINT GAMEOBJECT IS NOT SET ON CMCAMERA ADD ITEM SCRIPT");
        }
        items = new List<GameObject>();
        inventory = GameObject.Find("Inventory");
        objectiveManager = GameObject.Find("ObjectiveManager");
        objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;   
        if (Physics.Raycast(transform.position, transform.forward,out hit, distance) && !PlayerMovement.stopMovement)
        {
            // highlites if either object is Interactable
            // Layer 11 refers to collectable items (toys , Pictures , etc)
            // Layer 14 refers to collected items that are not collectables (keys , clothes, etc)
            if (hit.transform.gameObject.layer == 14 || hit.transform.gameObject.layer == 11)
            {
                reticle.HighliteObject();
            }

            if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.layer == 14)
            {
                if (hit.transform.name == objectiveManagerScript.itemNames[objectiveManagerScript.collectProgress])
                {
                    MouseLook.canLook = false;
                    PlayerMovement.stopMovement = true;

                    pickUpArm.SetActive(true);
                    hitGameobject = hit.transform.gameObject;
                   
                    StartCoroutine(WaitForHalfASecond());
                   
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.layer == 11)
            {
                PlayerMovement.stopMovement = true;
                MouseLook.canLook = false;
                pickUpArm.SetActive(true);
                // saves name of object
                items.Add(hit.transform.gameObject);
                hitGameobject = hit.transform.gameObject;
              
                StartCoroutine(CollectablesHalfASecond());
            }
            
        }
    }    
    // waits half second for non collectable items
    IEnumerator WaitForHalfASecond()
    {

        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", true);
        yield return new WaitForSeconds(0.5f);
        hitGameobject.transform.position = hand.transform.position + new Vector3(0, 0, -0.05f); ;
        hitGameobject.transform.parent = hand.transform;
        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", false);
        // adds item progress to manager
        objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
        objectiveManager.GetComponent<ObjectiveManager>().Objective();
        yield return new WaitForSeconds(1);
       // disables arms and collected gameobject
        pickUpArm.SetActive(false);
        hitGameobject.transform.gameObject.SetActive(false);
        //movement resumed
        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;

    }
    // waits half second for collectbles
    IEnumerator CollectablesHalfASecond()
    {
        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", true);
        yield return new WaitForSeconds(0.5f);
        hitGameobject.transform.position = hand.transform.position + new Vector3(0,0, 0);
        hitGameobject.transform.parent = hand.transform;
        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", false);
       // adds item progress to manager
        objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
        objectiveManager.GetComponent<ObjectiveManager>().Objective();
        // saves item into the inventory
        inventory.GetComponent<Inventory>().inventory(hitGameobject.transform.gameObject.name);
        
        yield return new WaitForSeconds(1);
        // disables arms and collected gameobject
        pickUpArm.SetActive(false);
        hitGameobject.transform.gameObject.SetActive(false);
        //movement resumed
        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;

    }

}
