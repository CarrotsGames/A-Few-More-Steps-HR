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
        carnivalGames = GameObject.Find("CarnivalGamesManager");
        playingGame = false;
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<RingToss>().enabled = false;
        player.GetComponent<Shooting>().enabled = false;
        player.GetComponent<StrengthTest>().enabled = false;
        //  staminaSlider.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {         
            gameManager.GetComponent<GameManager>().ResumePlayerControls();             
            player.GetComponent<RingToss>().enabled = false;
            player.GetComponent<Shooting>().enabled = false;
            player.GetComponent<StrengthTest>().enabled = false;
            player.GetComponent<ThrowBall>().enabled = false;

            if (staminaSlider != null)
            {
                if (staminaSlider.activeSelf)
                {
                    staminaSlider.SetActive(false);
                }
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
                        carnivalGames.GetComponent<CarnivalGamesManager>().RestartRingToss();
                        player.GetComponent<RingToss>().enabled = true;
                    }
                    break;
                case "DuckShooting":
                    {
                        // staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGamesManager>().RestartDuckGame();
                      //  CarnivalGameRules.RingTossInProgress = true;
                        player.GetComponent<Shooting>().enabled = true;
                    }
                    break;
                case "StrengthTest":
                    {
                        gameManager.GetComponent<GameManager>().StopPLayerControls();
                        // staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGamesManager>().RestartStrengthTest();
                        //  CarnivalGameRules.RingTossInProgress = true;
                        player.GetComponent<StrengthTest>().enabled = true;
                        staminaSlider.SetActive(true);
                    }
                    break;
                case "DunkTank":
                    {
                        //gameManager.GetComponent<GameManager>().StopPLayerControls();
                        // staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGamesManager>().RestartDunkTank();
                        CarnivalGamesManager.startDunkGame = true;
                        player.GetComponent<ThrowBall>().enabled = true;
                        staminaSlider.SetActive(true);

                    }
                    break;
            }
        }
    }
    void GameType()
    {
       
    }
}
