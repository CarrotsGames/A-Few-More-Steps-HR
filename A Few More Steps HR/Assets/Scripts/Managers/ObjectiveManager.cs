using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject screenFade;

    [Header("What are the objectives? (Collect, Talk, GoTo )")]
    public string[] objectives;
    private string objectiveType;

    [Header("Tell player what to do")]
    public string[] info;
    public Text infoText;
  
    // Collect X items
    [Header("how many items does the player collect?")]
    public int[] amountOfItems;
    [HideInInspector]
    public int itemCollected;
  
    // Talk to objective
    [Header("Who does player have to talk to?")]
    public string[] talkToPerson;
    [HideInInspector]
    public string playerTalkedTo;
    
    // GoTo area
    [Header("Where does the player go?")]
    public string[] goToArea;
    [HideInInspector]
    public string currentArea;
     

    ////[Header("What does the player need to pick up?")]
    ////public string specificItem;
    ////private string item;
    [SerializeField]
    private int progressCap;
    // the progress of all objectives
    private int progress;
    // the progress of each objective
    private int talkProgress;
    private int collectProgress;
    private int goToProgress;

    // Start is called before the first frame update
    void Start()
    {
        if(screenFade == null)
        {
            Debug.LogError("No Screenfade assigned!!");
        }
        collectProgress = 0;
        talkProgress = 0;
        progressCap = amountOfItems.Length + talkToPerson.Length;
        ObjectiveSteps();
        // gets amount of objectives the level has
        if(infoText == null)
        {
            Debug.LogError("Forgot to set the infoText in objectiveManager");
        }

    }
    // Handles the progression of the objectives
    void ObjectiveSteps()
    {
         infoText.text = info[progress];
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
             case 5:
                 objectiveType = objectives[progress];
                 Objective();
                 break;

         }
        
    }
    // keeps all info of what needs to be done with each objective
   public void Objective()
    {
        switch(objectiveType)
        {
            case "Collect":
                if(itemCollected >= amountOfItems[collectProgress])
                {
                    progress++;
                    collectProgress++;
                    ResetObjectiveStats();
                    Debug.Log("ObjectiveComplete!!");
                    ObjectiveSteps();
                }
                break;
            case "Talk":
                if (playerTalkedTo == talkToPerson[talkProgress])
                {
                    progress++;
                    talkProgress++;
                    ResetObjectiveStats();
                    Debug.Log("ObjectiveComplete!!");
                    ObjectiveSteps();
                }
                break;
            case "GoTo":
              
                if (currentArea == goToArea[goToProgress])
                {
                    if (progress >= progressCap)
                    {
                        infoText.text = "";
                        screenFade.GetComponent<ScreenFade>().BeginFadeOut();
                        Debug.Log("ALL OBJECTIVES COMPLETE");
                    }
                    else
                    {
                        progress++;
                        goToProgress++;
                        ResetObjectiveStats();
                        Debug.Log("ObjectiveComplete!!");
                        ObjectiveSteps();
                    }
                }
                
                break;
     

        }
    }
    void ResetObjectiveStats()
    {
        playerTalkedTo = "";
        currentArea = "";
        itemCollected = 0;
    }
}
