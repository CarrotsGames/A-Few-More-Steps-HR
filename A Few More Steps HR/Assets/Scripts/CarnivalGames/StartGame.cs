using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Name of game script used for this event")]
    public string gametype;
    private GameObject player;
    private GameObject gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.GetComponent<GameManager>().StopMovement();            
        }
    }
    void GameType()
    {
        switch(gametype)
        {
            case "RingToss":
                {
                    //Get ringtoss control script
                }
                break;
        }
    }
}
