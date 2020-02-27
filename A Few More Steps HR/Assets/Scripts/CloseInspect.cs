using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInspect : MonoBehaviour
{
    GameObject go;
    public static bool disableItem;
    private void Start()
    {
        go = GameObject.Find("Inventory");
        this.gameObject.SetActive(false);
    }
    public void StopInspecting()
    {
        // turns of exit button
        this.gameObject.SetActive(false);
        // enabled inventory
        go.SetActive(true);     
        // disabled inspecting item
        disableItem = true;
    }
}
