﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject noteUi;
    public string noteText;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (noteUi.activeInHierarchy)
        {
            noteUi.SetActive(false);
        }
    }
    public void ReadNote()
    {
        Cursor.lockState = CursorLockMode.None;
        MouseLook.canLook = false;
        player.GetComponent<CharacterController>().enabled = false;
        noteUi.transform.GetChild(0).GetComponent<Text>().text = noteText;
        noteUi.SetActive(true);
     //   EnableCamera.stopTakingPhotos = true;
    }   
}
