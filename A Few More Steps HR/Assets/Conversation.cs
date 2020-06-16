 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Conversation : MonoBehaviour
{
    [TextArea(1, 200)]
 
    private int amountOfDialogue;
    private int chatProgress;
    public GameObject chatBoxGameObj;
    public Text chatBox;
    public int waitFor = 3;
    private IEnumerator coroutine;
    public PointList ListOfPointLists = new PointList();
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    [System.Serializable]
    public class Point
    {
        public List<string> numOfConversations;
    }

    [System.Serializable]
    public class PointList
    {
        public List<Point> GameProgress;
    }

    private void Start()
    {
         
        chatProgress = 0;
        objectiveManager = GameObject.Find("ObjectiveManager");
        objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();

        chatBoxGameObj = GameObject.Find("ChatBox");
        if(chatBoxGameObj == null)
        {
            Debug.LogError("ChatBox is null");
        }
    }
 
    void CheckPart()
    {
         
        switch (GameManager.dialogueParts)
        {
            case 0:
                if (chatProgress < ListOfPointLists.GameProgress[0].numOfConversations.Count)
                {                
                    chatBox.text = ListOfPointLists.GameProgress[0].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[0].numOfConversations.Count;
                }
                break;
            case 1:
                if (chatProgress < ListOfPointLists.GameProgress[1].numOfConversations.Count)
                {
                    chatBox.text = ListOfPointLists.GameProgress[1].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[1].numOfConversations.Count;
                }
                break;
            case 2:
                if (chatProgress < ListOfPointLists.GameProgress[2].numOfConversations.Count)
                {
                    chatBox.text = ListOfPointLists.GameProgress[2].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[2].numOfConversations.Count;
                }
                break;
            case 3:
                if (chatProgress < ListOfPointLists.GameProgress[3].numOfConversations.Count)
                {
                    chatBox.text = ListOfPointLists.GameProgress[3].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[3].numOfConversations.Count;
                }
                break;
            case 4:
                if (chatProgress < ListOfPointLists.GameProgress[4].numOfConversations.Count)
                {
                    chatBox.text = ListOfPointLists.GameProgress[4].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[4].numOfConversations.Count;
                }
                break;
            case 5:
                if (chatProgress < ListOfPointLists.GameProgress[5].numOfConversations.Count)
                {
                    chatBox.text = ListOfPointLists.GameProgress[5].numOfConversations[chatProgress];
                    amountOfDialogue = ListOfPointLists.GameProgress[5].numOfConversations.Count;
                }
                break;
        }

    }
    public void StartConversation()
    {
        
        chatBoxGameObj.SetActive(true);
        CheckPart();
       // chatBox.text = chat[chatProgress];
        chatProgress++;
        if (chatProgress < amountOfDialogue)
        {
            coroutine = NextChat();
            StartCoroutine(NextChat());
        }
        else
        {
            DisableText();
            if(ObjectiveManager.talkingObjBool)
            {
                objectiveManagerScript.ObjectiveSteps();
            }
        }
    }
    public void DisableText()
    {
        coroutine = RemoveText();
        StartCoroutine(RemoveText());
         
    }
    public IEnumerator NextChat()
    {
        while (true) // you can put there some other condition
        {
            yield return new WaitForSeconds(waitFor);
            StartConversation();
        }
    }
    public IEnumerator RemoveText()
    {
        while (true) // you can put there some other condition
        {
           
            yield return new WaitForSeconds(waitFor);
            Talking.inConversation = false;
            chatBox.text = "";
            chatProgress = 0;
            StopAllCoroutines();
        }
    }
}
