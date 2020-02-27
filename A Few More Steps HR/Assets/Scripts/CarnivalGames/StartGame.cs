using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Name of game script used for this event")]
    public string gametype;
    private GameObject player;
    private GameObject gameManager;
    private GameObject carnivalGames;
    public static bool playingGame;
    private void Start()
    {
        carnivalGames = GameObject.Find("CarnivalGameRules");
        playingGame = false;
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {         
            gameManager.GetComponent<GameManager>().ResumePlayerControls();
            carnivalGames.GetComponent<CarnivalGameRules>().ReloadRings();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && other.tag == "Player")
        {
            playingGame = true;
            gameManager.GetComponent<GameManager>().StopMovement();
            switch (gametype)
            {
                case "RingToss":
                    {
                        player.GetComponent<RingToss>().enabled = true;
                    }
                    break;
            }
        }
    }
    void GameType()
    {
       
    }
}
