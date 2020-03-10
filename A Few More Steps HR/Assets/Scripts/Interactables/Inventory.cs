using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inHouse = false;
    [Header("Items picked up by player (Visible for debugging)")]
    public List<string> collectedItems;
    private GameObject saveManager;
    [Header("Items placed in the house")]
    public GameObject[] collectables;
   // [Header("Items with pick up layer")]
   // public GameObject[] pickUps;

    private void Start()
    {
        collectedItems = new List<string>();
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
    void EnableCollectable(int collectableNum)
    {
      
        if (inHouse)
        {
            collectables[collectableNum].SetActive(true);
        }
    }
    public void inventory(string itemName )
    {
        // adds collected item name for saving
        // this is always added so when saving it will save all found items
        // even when found in previous levels
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
        }
        switch (itemName)
        {
            case "A":
                // Spawns the saved inventory items into the house
                // CHECK IF IN HOUSE SCENES COLLECTABLES ARE ONLY IN HOUSE SCENES!!!!    
                EnableCollectable(0);
                // pickUps[0].gameObject.SetActive(false);          
                // ALWAYS SAVE INVENTORY
                
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
                break;
            case "B":
                EnableCollectable(1);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
                break;
            case "C":
                EnableCollectable(2);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
            case "D":
                EnableCollectable(3);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
    
                break;
            case "E":
                EnableCollectable(4);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
            case "F":
                EnableCollectable(5);
                saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
        }
    }
}
