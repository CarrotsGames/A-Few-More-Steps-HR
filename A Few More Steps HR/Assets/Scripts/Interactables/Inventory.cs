using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
 
    public List<GameObject> collectedItems;
    private GameObject saveManager;
    [Header("Items placed in the house")]
    public GameObject[] collectables;
    [Header("Items with pick up layer")]
    public GameObject[] pickUps;

    private void Start()
    {
        collectedItems = new List<GameObject>();
        saveManager = GameObject.Find("SaveManager");
        saveManager.GetComponent<ItemSaveManager>().LoadInventory(this);
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.L))
        {
            saveManager.GetComponent<ItemSaveManager>().LoadInventory(this);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
        }
    }

    public void inventory(string itemName)
    {
        
        switch (itemName)
        {
            case "A":
                // Spawns the saved inventory items into the house
                // CHECK IF IN HOUSE SCENES COLLECTABLES ARE ONLY IN HOUSE SCENES!!!!
                collectables[0].gameObject.SetActive(true);
                pickUps[0].gameObject.SetActive(false);
                collectedItems.Add(collectables[0]);
                // disables ingame collectable
                // pickUps[0].SetActive(false);           
                // ALWAYS SAVE INVENTORY
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
                break;
            case "B":
                collectables[1].gameObject.SetActive(true);
                pickUps[1].gameObject.SetActive(false);
                collectedItems.Add(collectables[1]);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
                break;
            case "C":
                collectables[2].gameObject.SetActive(true);
                pickUps[2].gameObject.SetActive(false);
                collectedItems.Add(collectables[2]);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
            case "D":
                collectables[3].gameObject.SetActive(true);
                pickUps[3].gameObject.SetActive(false);
                collectedItems.Add(collectables[3]);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
    
                break;
            case "E":
                collectables[4].gameObject.SetActive(true);
                pickUps[4].gameObject.SetActive(false);
                collectedItems.Add(collectables[4]);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
            case "F":
                collectables[5].gameObject.SetActive(true);
                pickUps[5].gameObject.SetActive(false);
                collectedItems.Add(collectables[5]);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
        }
    }
}
