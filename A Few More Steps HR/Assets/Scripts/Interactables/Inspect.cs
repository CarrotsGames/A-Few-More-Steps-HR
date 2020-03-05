using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour
{
   public GameObject exit;
   [SerializeField]
   public string itemName;
   
  
    public void InspectItem(GameObject Item)
    {
        // item can no longer be disabled
        CloseInspect.disableItem = false;
        // turns on inspectCamera
        Item.SetActive(true);
        for (int i = 0; i < Item.transform.childCount; i++)
        {
            if(Item.transform.GetChild(i).name == itemName)
            {
                // enables object
                Item.transform.GetChild(i).gameObject.SetActive(true);
                // sets object to default positions
                Item.transform.GetChild(i).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                // disabled inventory to save space
                this.transform.parent.gameObject.SetActive(false);
                // exit button is revealed
                exit.SetActive(true);

            }
        }
    }
}
