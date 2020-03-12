using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private GameObject objectiveManager;
    public static bool changeConversation;
    private void Start()
    {
        changeConversation = true;
        objectiveManager = GameObject.Find("ObjectiveManager");
    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //if(!changeConversation)
            //{
            //    changeConversation = true;
            //}
            //changeConversation = false;
            other.GetComponentInParent<Conversation>().StartConversation();
            Debug.Log("talking to " + other.name);
            objectiveManager.GetComponent<ObjectiveManager>().playerTalkedTo = other.name;
            objectiveManager.GetComponent<ObjectiveManager>().Objective();
        }
    }
}
