using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{

    [SerializeField] ItemDatabase itemDataBase;
    // name of save file
    private const string InventoryFileName = "Inventory";
    // private const string ItemInGame = "Inventory";


    // JUST SAVED INVENTORY GOTTEN FROM THE INVENTORY SCRIPT ON CANVAS
    public void LoadInventory(Inventory inventory)
    {
        // Gets number of saved items
        ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);

         if (savedSlots == null) return;
         // Goes through amount of saved items 
         for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
         {
            // Gets name of saved object and unlocks it in inventory
             inventory.inventory(savedSlots.SavedSlots[i].itemID);
            
         }
         
    }

    public void SaveInventory(Inventory inventory)
    {
        // saves current collectables along with the filename
        SaveItems(inventory.collectedItems, InventoryFileName);
    }
       
    // Gets saved list
    private void SaveItems(IList<string> ItemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData(ItemSlots.Count);
        // saves list stuff 
        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            
            // saves each item collected into a file
            string itemSlot = ItemSlots[i];
            if(itemSlot == null)
            {
                saveData.SavedSlots[i] = null;
            }
            else
            {
                saveData.SavedSlots[i] = new ItemsaveData(itemSlot);
                ItemSaveIO.SaveItems(saveData, fileName);
            }
        }
    }
}
