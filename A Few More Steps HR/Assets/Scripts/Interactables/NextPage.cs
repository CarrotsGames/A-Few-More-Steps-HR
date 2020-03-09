using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    // Notes are set in inspector by dragging in
    // the number of textnote GameObjects wanted in the scene
    public GameObject[] notes;
    public int numberOfPages;
    private int pageTurned;
    // changes pages when pressed. When no pages the notes
    // will be deactivated
    public void Next()
    {
        notes[pageTurned].SetActive(false);
        pageTurned++;

        if (pageTurned < numberOfPages)
        {
            notes[pageTurned].SetActive(true);
        }
        else if (pageTurned >= numberOfPages)
        {
            pageTurned = 0;
            GetComponent<Close>().CloseItem();
        }
    }
}
