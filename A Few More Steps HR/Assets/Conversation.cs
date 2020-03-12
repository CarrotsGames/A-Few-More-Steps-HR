using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [TextArea(1, 200)]
    public string chat;
    public GameObject chatBoxGameObj;
    public Text chatBox;
    public int waitFor = 3;
    public bool a;
    private IEnumerator coroutine;
    private void Start()
    {
        a = false;
        chatBoxGameObj = GameObject.Find("ChatBox");
        if(chatBoxGameObj == null)
        {
            Debug.LogError("ChatBox is null");
        }
    }
    //private void Update()
    //{
       
    //    if (Talking.changeConversation)
    //    {
    //        Debug.Log("New convo");
    //        coroutine = Stop();
    //        StartCoroutine(Stop());   
    //    }
    //}
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(0);
        StopAllCoroutines();
        chatBox.text = "";
        a = false;
    }
    public void StartConversation()
    {
        
        chatBoxGameObj.SetActive(true);
        chatBox.text = chat;
        DisableText();
    }
    public void DisableText()
    {
        coroutine = RemoveText();
        StartCoroutine(RemoveText());
         
    }
    public IEnumerator RemoveText()
    {
        while (true) // you can put there some other condition
        {
           
            yield return new WaitForSeconds(waitFor);
            Talking.changeConversation = true;
            chatBox.text = "";
            StopAllCoroutines();
        }
    }
}
