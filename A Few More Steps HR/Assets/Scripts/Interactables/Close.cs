using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Close : MonoBehaviour
{
    public GameObject note;

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CloseItem()
    {
        // locks cursor and enables movement
        Cursor.lockState = CursorLockMode.Locked;
        MouseLook.canLook = true;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterController>().enabled = true;
        //transform.parent.gameObject.SetActive(false);
        note.SetActive(false);
    }
}
