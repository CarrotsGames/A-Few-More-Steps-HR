using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    private GameObject objectiveManager;
    private void Start()
    {
       objectiveManager = GameObject.Find("ObjectiveManager");
    }
    private void OnTriggerEnter(Collider other)
    {
        objectiveManager.GetComponent<ObjectiveManager>().currentArea = other.name;
        objectiveManager.GetComponent<ObjectiveManager>().Objective();
    }
}
