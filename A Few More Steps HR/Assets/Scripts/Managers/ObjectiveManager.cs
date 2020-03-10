using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [Header("What are the objectives? (Collect, Talk, GoTo )")]
    public string[] objectives;
    private string objectiveType;
    // Collect X items
    [Header("how many items does the player collect?")]
    public int[] amountOfItems;
    [HideInInspector]
    public int itemCollected;
    // Talk to objective
    [HideInInspector]
    public string playerTalkedTo;
    [Header("Who does player have to talk to?")]
    public string[] talkToPerson;
    public int progressCap;
   
    // the progress of all objectives
    private int progress;
    // the progress of each objective. Reason for it being like this is so it keeps 
    // track of each talking/collecting array progress. for eg if we start with amountofitems[progress] then when 
    // progress upgrades it will be 1 and if the next obejctive is talktoperson then the player would have to talk to person[1] which
    // could be out of range in most cases.
    private int talkProgress;
    private int collectProgress;
   
    // Start is called before the first frame update
    void Start()
    {
        collectProgress = 0;
        talkProgress = 0;
        ObjectiveSteps();
    }

    void ObjectiveSteps()
    {
        if (progress >= progressCap)
        {
            Debug.Log("ALL OBJECTIVES COMPLETE");
        }
        else
        {
            switch (progress)
            {
                case 0:
                    objectiveType = objectives[progress];
                    // ADD STRING/TEXT THAT TELLS PLAYER WHAT TO DO 
                    Objective();
                    break;
                case 1:
                    objectiveType = objectives[progress];
                    Objective();
                    break;
                case 2:
                    objectiveType = objectives[progress];
                    Objective();
                    break;
                case 3:
                    objectiveType = objectives[progress];
                    Objective();
                    break;
                case 4:
                    objectiveType = objectives[progress];
                    Objective();
                    break;

            }
        }
    }

   public void Objective()
    {
        switch(objectiveType)
        {
            case "Collect":
                if(itemCollected >= amountOfItems[collectProgress])
                {
                    progress++;
                    collectProgress++;
                    itemCollected = 0;
                    Debug.Log("ObjectiveComplete!!");
                    ObjectiveSteps();
                }
                break;
            case "Talk":
                if (playerTalkedTo == talkToPerson[talkProgress])
                {
                    progress++;
                    talkProgress++;
                    playerTalkedTo = "";
                    Debug.Log("ObjectiveComplete!!");

                    ObjectiveSteps();
                }
                break;
            //case "GoTo":
            //    if (playerTalkedTo == talkToPerson[progress])
            //    {
            //        progress++;
            //        ObjectiveSteps();
            //    }
            //    break;

        }
    }
}
