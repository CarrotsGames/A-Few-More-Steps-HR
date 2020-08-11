using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    [Header("FDFC is only used in house scenes")]
    public GameObject finalDoorFpsCam;
    [HideInInspector]
    public GameObject animationManager;
    private GameObject cutsceneFade;
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    private AnimationManager animationManagerScript;
    private void Start()
    {
      
       objectiveManager = GameObject.Find("ObjectiveManager");
       objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();
       cutsceneFade = GameObject.Find("ScreenFade");
       animationManager = GameObject.Find("AnimationManager");
       if (animationManager != null)
       {
           animationManagerScript = animationManager.GetComponent<AnimationManager>();
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        objectiveManager.GetComponent<ObjectiveManager>().currentArea = other.name;
        if (other.tag == "FinalDoor")
        {
            MouseLook.canLook = false;
            PlayerMovement.stopMovement = true;

            //if (finalDoorGo == null)
            //{
            //    Debug.LogError("FinalDoorCam not assigned");
            //}
           // StartCoroutine(OpeningFinalDoor(other.gameObject));
            animationManagerScript.AnimationName("FinalDoor" ,other.gameObject);
        }
     
        else
        {
            objectiveManager.GetComponent<ObjectiveManager>().Objective();
        }
    }
 
}
