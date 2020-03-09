using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public GameObject noteUi;   
    [TextArea(15, 20)]
    public string[] noteText;
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
        for (int i = 0; i < noteText.Length; i++)
        {
            noteUi.transform.GetChild(i + 1).GetComponent<Text>().text = noteText[i];
        }
        noteUi.transform.GetChild(0).transform.GetComponent<NextPage>().numberOfPages = noteText.Length;
        noteUi.SetActive(true);
        noteUi.transform.GetChild(1).gameObject.SetActive(true);
     //   EnableCamera.stopTakingPhotos = true;
    }   
}
