using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talking : MonoBehaviour
{
    private GameObject objectiveManager;
    public static bool inConversation;
    private void Start()
    {
        inConversation = false;
        objectiveManager = GameObject.Find("ObjectiveManager");
    }
    private void OnTriggerStay(Collider other)
    {
        if (!inConversation)
        {            
            if (Input.GetKeyDown(KeyCode.E))        
            {
                inConversation = true;       
                other.GetComponentInParent<Conversation>().StartConversation();      
                Debug.Log("talking to " + other.name);       
                objectiveManager.GetComponent<ObjectiveManager>().playerTalkedTo = other.name;      
                objectiveManager.GetComponent<ObjectiveManager>().Objective();       
            }

        }
    }
}
