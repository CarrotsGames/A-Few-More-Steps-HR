using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour
{
    public GameObject gameManager;
    public LayerMask mask;
    public GameObject exit;
    [SerializeField]
    public string itemName;
    public GameObject itemStorage;
    public GameObject inpsectCamera;
    // This is also being called in pause script to check if player can pause
    public static bool inspectingItem;
    private void Start()
    {
        inspectingItem = false;
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, mask))
        {
            if(Input.GetKeyDown(KeyCode.E) && !inspectingItem)            
            {
                Debug.Log("InspectMe");
                gameManager.GetComponent<GameManager>().StopPlayerControls();
                InspectItem(hit.transform.gameObject);
                inspectingItem = true;
                Cursor.lockState = CursorLockMode.Confined;
                exit.SetActive(true);
            }
            
        }
        //if(inspectingItem)
        //{
        //    // freezes players movement until player exits inspect
        //    gameManager.GetComponent<GameManager>().StopPlayerControls();
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        //itemStorage.transform.GetChild(i).gameObject.SetActive(false);
        //        inpsectCamera.SetActive(false);

        //    }
        //}
    }
    public void InspectItem(GameObject Item)
    {
        inspectingItem = true;
        inpsectCamera.SetActive(true);
        // item can no longer be disabled
        CloseInspect.disableItem = false;
        // turns on inspectCamera
        for (int i = 0; i < itemStorage.transform.childCount; i++)
        {
            itemStorage.transform.GetChild(i).gameObject.SetActive(false);
            if ( itemStorage.transform.GetChild(i).name == Item.name)
            {
                itemStorage.transform.GetChild(i).gameObject.SetActive(true);
                itemStorage.transform.GetChild(i).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            }
        }
      
    }


}
