using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static bool talkingObjBool;
    public GameObject screenFade;
    [Header("Which objective should the dialogue change?")]
    public int changeDialogue;
    [Header("What are the objectives? (Collect, Talk, GoTo )")]
    public string[] objectives;
   
    [Header("Tell player what to do")]
    public string[] info;
    public Text infoText;

    // Collect X items
    [Header("how many items does the player collect?")]
    [Header("NOTE: Layer 11 item names are its tag")]
    public string[] itemNames;
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
    public static bool levelEnded;
  
    // the progress of all objectives
    public int progress;
    [HideInInspector]
    public int collectProgress;
   
    [SerializeField]
    private int progressCap;
    // the progress of each objective
    private int talkProgress;
    private int goToProgress; 
   
    //used to switch off highliteReticle
    private GameObject highliteReticle;
    private string objectiveType;
   
    // Start is called before the first frame update
    void Start()
    {
        highliteReticle = GameObject.Find("Reticle");
        levelEnded = false;
        if (screenFade == null)
        {
            Debug.LogError("No Screenfade assigned!!");
        }
        collectProgress = 0;
        talkProgress = 0;
        progressCap = amountOfItems.Length + talkToPerson.Length + goToArea.Length;
        ObjectiveSteps();
        // gets amount of objectives the level has
        if(infoText == null)
        {
            Debug.LogError("Forgot to set the infoText in objectiveManager");
        }
    }
    public void HideText()
    {
        infoText.text = "";
        highliteReticle.GetComponent<reticle>().DisableReticle();
    }
    public void ShowText()
    {
        infoText.text = info[progress];
        highliteReticle.GetComponent<reticle>().EnableReticle();

    }
    // Handles the progression of the objectives
    public void ObjectiveSteps()
    {
        infoText.text = info[progress];
        if(progress == changeDialogue)
        {          
            changeDialogue--;
        }
        // PLAY AUDIO CLIP
        // CHECK WHEN AUDIO CLIP IS OVER
        // SHOW INFO TEXT
         switch (progress)
         {
             case 0:
                 levelEnded = false;
                 objectiveType = objectives[progress];
                 GameManager.dialogueParts = 0;
                // ADD STRING/TEXT THAT TELLS PLAYER WHAT TO DO 
                Objective();
                 break;
             case 1:
                 objectiveType = objectives[progress];
                GameManager.dialogueParts = 1;

                Objective();
                 break;
             case 2:
                 objectiveType = objectives[progress];
                GameManager.dialogueParts = 2;
                Objective();
                 break;
             case 3:
                 objectiveType = objectives[progress];
                GameManager.dialogueParts = 3;
                Objective();
                 break;
             case 4:
                 objectiveType = objectives[progress];
                GameManager.dialogueParts = 4;
                Objective();
                 break;
             case 5:
                 objectiveType = objectives[progress];
                GameManager.dialogueParts = 5;
                Objective();
                 break;

         }
        
    }
    // keeps all info of what needs to be done with each objective
   public void Objective()
    { 
        if(!levelEnded)
        {

            switch (objectiveType)
            {
                // Collect objects like keys , toys etc
                case "Collect":
                    if (itemCollected >= amountOfItems[collectProgress])
                    {
                        progress++;

                        // when all objectives are done
                        if (progress >= progressCap)
                        {
                            EndScene();
                        }
                        else
                        {
                            collectProgress++;
                            ResetObjectiveStats();
                            Debug.Log("ObjectiveComplete!!");
                            ObjectiveSteps();
                        }
                    }
                    break;
                    //talk to npcs
                case "Talk":
                    if (playerTalkedTo == talkToPerson[talkProgress])
                    {
                        progress++;
                        talkingObjBool = true;
                        if (progress >= progressCap)
                        {
                            EndScene();
                        }
                        else
                        {
                            talkProgress++;
                            ResetObjectiveStats();
                            Debug.Log("ObjectiveComplete!!");                        
                        }
                    }
                    break;
                    // go to a specific area
                case "GoTo":

                    if (currentArea == goToArea[goToProgress])
                    {
                        progress++;

                        if (progress >= progressCap)
                        {
                            EndScene();
                        }
                        else
                        {
                          
                            goToProgress++;
                            ResetObjectiveStats();
                            Debug.Log("ObjectiveComplete!!");
                            ObjectiveSteps();
                        }
                    }

                    break;
            }

        }
    }
    void EndScene()
    {
        screenFade.GetComponent<ScreenFade>().StopAllCoroutines();

        screenFade.GetComponent<ScreenFade>().BeginFadeOut();
        GameManager.dialogueParts = 0;
        progress = 0;
        infoText.text = "";
        levelEnded = true;
        Debug.Log("ALL OBJECTIVES COMPLETE");
    }
    void ResetObjectiveStats()
    {
        playerTalkedTo = "";
        currentArea = "";
        itemCollected = 0;
    }
}
