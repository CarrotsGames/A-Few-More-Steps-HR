using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
 
    [Header("Collected Items")]
    public List<GameObject> collectables;
    private GameObject saveManager;
    
    private void Start()
    {
        collectables = new List<GameObject>();
        saveManager = GameObject.Find("SaveManager");
   
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
                transform.GetChild(0).gameObject.SetActive(true);
             //   saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);
                break;
            case "B":
                transform.GetChild(1).gameObject.SetActive(true);
               // saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
            case "C":
                transform.GetChild(2).gameObject.SetActive(true);
             //   saveManager.GetComponent<ItemSaveManager>().SaveInventory(this);

                break;
        }
    }
}
