using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [TextArea(1, 200)]
    // Look into list within lists to show in inspector to
    // make this less cluttered
    public string[] partOneChat;
    public string[] partTwoChat;
    public string[] partThreeChat;
    private int amountOfDialogue;
    private int chatProgress;
    public GameObject chatBoxGameObj;
    public Text chatBox;
    public int waitFor = 3;
    

    private IEnumerator coroutine;
    private void Start()
    {
        chatProgress = 0;
 
        chatBoxGameObj = GameObject.Find("ChatBox");
        if(chatBoxGameObj == null)
        {
            Debug.LogError("ChatBox is null");
        }
    }
 
    void CheckPart()
    {
        switch(GameManager.dialogueParts)
        {
            case 0:
                chatBox.text = partOneChat[chatProgress];
                amountOfDialogue = partOneChat.Length;
                break;
            case 1:
                chatBox.text = partTwoChat[chatProgress];
                amountOfDialogue = partTwoChat.Length;

                break;
            case 2:
                chatBox.text = partThreeChat[chatProgress];
                amountOfDialogue = partThreeChat.Length;

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
