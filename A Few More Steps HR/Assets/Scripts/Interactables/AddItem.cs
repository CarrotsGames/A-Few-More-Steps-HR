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
    private void Start()
    {
        items = new List<GameObject>();
        inventory = GameObject.Find("Inventory");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit, distance, mask) && !PlayerMovement.stopMovement)
        {
            reticle.HighliteObject();

            if (Input.GetKeyDown(KeyCode.E))
            {
                // saves name of object
                items.Add(hit.transform.gameObject);
                inventory.GetComponent<Inventory>().collectedItems.Add(hit.transform.gameObject);
                // inventory.GetComponent<Inventory>().
                // saves item into the inventory
                inventory.GetComponent<Inventory>().inventory(hit.transform.gameObject.name);
                hit.transform.gameObject.SetActive(false);
                Debug.Log(hit.transform.name + "Has been collected!!!");
            }
        }
        else
        {
            reticle.disableHighlite();
        }
    }
}
