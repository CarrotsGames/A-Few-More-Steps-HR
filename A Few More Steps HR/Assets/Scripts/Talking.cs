using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private GameObject objectiveManager;
    private void Start()
    {
        objectiveManager = GameObject.Find("ObjectiveManager");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TalkingRange");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("talking to " + other.name);
            objectiveManager.GetComponent<ObjectiveManager>().playerTalkedTo = other.name;
            objectiveManager.GetComponent<ObjectiveManager>().Objective();
        }
    }
}
