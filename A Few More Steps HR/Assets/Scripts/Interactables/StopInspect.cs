using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopInspect : MonoBehaviour
{
    public GameObject itemStore;
    public GameObject gameManager;
    public GameObject inspectCamera;
     private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        Debug.Log(this.gameObject);
    }
    public void Exit()
    {
        for (int i = 0; i < itemStore.transform.childCount; i++)
        {
            if(itemStore.transform.GetChild(i).gameObject.activeSelf)
            {
                Inspect.inspectingItem = false;
                this.gameObject.SetActive(false);
                inspectCamera.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                gameManager.GetComponent<GameManager>().ResumePlayerControls();
                itemStore.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
