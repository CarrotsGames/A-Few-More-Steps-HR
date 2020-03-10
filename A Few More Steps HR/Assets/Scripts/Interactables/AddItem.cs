using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public float distance;
    [Header("Collected Items")]
    public List<GameObject> items;
    public LayerMask mask;
    private GameObject inventory;
    private GameObject objectiveManager;
    private void Start()
    {
        items = new List<GameObject>();
        inventory = GameObject.Find("Inventory");
        objectiveManager = GameObject.Find("ObjectiveManager");

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit, distance, mask) && !PlayerMovement.stopMovement)
        {
            reticle.HighliteObject();

            if (Input.GetKeyDown(KeyCode.E))
            {
                // saves name of object
                items.Add(hit.transform.gameObject);
                objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
                objectiveManager.GetComponent<ObjectiveManager>().Objective();
                // saves item into the inventory
                inventory.GetComponent<Inventory>().inventory(hit.transform.gameObject.name);
                hit.transform.gameObject.SetActive(false);
                Debug.Log(hit.transform.name + "Has been collected!!!");
            }
        }
        else
        {
           // reticle.disableHighlite();
        }
    }
}
