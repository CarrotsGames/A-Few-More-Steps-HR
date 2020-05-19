using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject pickUpArm;
   
    public GameObject animationManager;

    public GameObject hand;
    public float distance;
    [Header("Collected Items")]
    public List<GameObject> items;
    public LayerMask mask;
    private GameObject inventory;
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    private AnimationManager animationManagerScript;

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
      
        animationManager = GameObject.Find("AnimationManager");
        animationManagerScript = animationManager.GetComponent<AnimationManager>();
        // Update is called once per frame
    }
    void Update()
    {
        
        RaycastHit hit;   
        if (Physics.Raycast(transform.position, transform.forward,out hit, distance) && !PlayerMovement.stopMovement)
        {
            // highlites if either object is Interactable
            // Layer 11 refers to collectable items that are added to the house scenes (toys , Pictures , etc)
            // Layer 14 refers to collected items that are not collectables but are used to progress in the level (keys , etc)
            // Layer 15 refers to picking up clothing so we can give it a custom animation (also adds to progress in level)
            if (hit.transform.gameObject.layer == 14 || hit.transform.gameObject.layer == 11 || hit.transform.gameObject.layer == 15)
            {
                reticle.HighliteObject();
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                ItemSorter(hit.transform.gameObject);
            }
                   
        }
    }
    void ItemSorter(GameObject Item)
    {
        switch (Item.transform.gameObject.layer)
        {
            // toys , pictures, pets
            case 11:
                if (Item.transform.name == objectiveManagerScript.itemNames[objectiveManagerScript.collectProgress])
                {
                    PlayerMovement.stopMovement = true;
                    MouseLook.canLook = false;
                    pickUpArm.SetActive(true);
                    // saves name of object
                    items.Add(Item.transform.gameObject);
                    hitGameobject = Item.transform.gameObject;
                    StartCoroutine(CollectablePickUp());
                }
                break;
                // Keys and other
            case 14:
                if (Item.transform.name == objectiveManagerScript.itemNames[objectiveManagerScript.collectProgress])
                {
                    MouseLook.canLook = false;
                    PlayerMovement.stopMovement = true;
                    pickUpArm.SetActive(true);
                    hitGameobject = Item.transform.gameObject;
                    StartCoroutine(NonCollectablePickUp());
                }
                break;
                // Clothing
            case 15:
                if (Item.transform.name == objectiveManagerScript.itemNames[objectiveManagerScript.collectProgress])
                {
                    MouseLook.canLook = false;
                    PlayerMovement.stopMovement = true;
                    // ClothingArm.transform.position += new Vector3(0, 0.25f, 0);
                    hitGameobject = Item.transform.gameObject;
                    if (hitGameobject.name == "Clothes")
                    {
                        animationManagerScript.AnimationName("Clothing", hitGameobject);
                    }
                    else if(hitGameobject.name == "BabyCrib")
                    {
                        animationManagerScript.AnimationName("BabyCrib", hitGameobject);
                    }

                }
                break;

        }
    }
    // waits half second for non collectable items
    IEnumerator NonCollectablePickUp()
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
    IEnumerator CollectablePickUp()
    {
        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", true);
        yield return new WaitForSeconds(0.5f);
        
        hitGameobject.transform.position = hand.transform.position + new Vector3(0,0, 0);
        hitGameobject.transform.parent = hand.transform;
        pickUpArm.GetComponent<Animator>().SetBool("PickUpItem", false);
        // adds item progress to manager
        // FUTURE NOTE REPLACE THESE WITH JUST "objectiveManagerScript"
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
