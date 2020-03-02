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
    public GameObject staminaSlider;
    private void Start()
    {
        carnivalGames = GameObject.Find("CarnivalGameRules");
        playingGame = false;
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<RingToss>().enabled = false;
      //  staminaSlider.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {         
            gameManager.GetComponent<GameManager>().ResumePlayerControls();             
            player.GetComponent<RingToss>().enabled = false;
            player.GetComponent<Shooting>().enabled = false;
            CarnivalGameRules.RingTossInProgress = false;
            CarnivalGameRules.duckGameInProgress = false;
            if (staminaSlider.activeSelf)
            {
                staminaSlider.SetActive(false);
            }
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
                        staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGameRules>().RestartRingToss();
                        player.GetComponent<RingToss>().enabled = true;
                    }
                    break;
                case "DuckShooting":
                    {
                        // staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGameRules>().RestartDuckGame();
                        CarnivalGameRules.RingTossInProgress = true;
                        player.GetComponent<Shooting>().enabled = true;
                    }
                    break;
            }
        }
    }
    void GameType()
    {
       
    }
}
