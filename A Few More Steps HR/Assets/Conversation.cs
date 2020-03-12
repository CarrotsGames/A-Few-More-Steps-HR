using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [TextArea(1, 200)]
    public string[] chat;
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
   
    public void StartConversation()
    {
        
        chatBoxGameObj.SetActive(true);
        chatBox.text = chat[chatProgress];
        chatProgress++;
        if (chatProgress < chat.Length)
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
