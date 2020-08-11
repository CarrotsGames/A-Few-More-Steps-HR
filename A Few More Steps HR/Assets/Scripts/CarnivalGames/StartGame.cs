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
    public GameObject staminaSlider;
    
    private Transform lookAt;
    // stops playing the mini game once won
    public static bool endTheGame;
    // Checks if player is playing game 
    public static bool playingGame;
    // because duck shooting doesent require stamina we use this bool to disable 
    // All stamina bar properties 
    private bool duckShooting;
    private void Start()
    {
        // gives slider a temporary position to avoid null refs
        
        carnivalGames = GameObject.Find("CarnivalGamesManager");
        endTheGame = false;
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
        if (Input.GetKeyUp(KeyCode.Escape) || endTheGame)
        {
            duckShooting = false;
            endTheGame = false;
            playingGame = false;
            //Resets all sliders when done
            gameManager.GetComponent<GameManager>().ResumePlayerControls();
            player.GetComponent<RingToss>().enabled = false;
            player.GetComponent<Shooting>().enabled = false;
            player.GetComponent<StrengthTest>().enabled = false;
            player.GetComponent<ThrowBall>().enabled = false;
            // if the sliders not already disabled, disable it
            if (staminaSlider != null)
            {
                if (staminaSlider.activeSelf)
                {
                    staminaSlider.SetActive(false);
                }
            }
        }
        if (!duckShooting)
        {
            if (staminaSlider != null)
            {
                if (!playingGame)
                {
                    staminaSlider.SetActive(false);
                }
                else
                {
                    staminaSlider.SetActive(true);
                }
            }
        }
        else
        {
            staminaSlider.SetActive(false);
        }
    }
    // Points camera to the game
    void LookAtGame()
    {
        lookAt = transform.GetChild(0).transform;
        // player.transform.position = transform.position + transform.up * 1;
        Vector3 lookPos = lookAt.position - player.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, Time.deltaTime * 100);
        //player.transform.LookAt(lookAt);
    }
    // checks which mini game the player is playing
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && other.tag == "Player")
        {
            playingGame = true;         
            gameManager.GetComponent<GameManager>().StopMovement();
            LookAtGame();
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
                        duckShooting = true;
                    }
                    break;
                case "StrengthTest":
                    {
                        gameManager.GetComponent<GameManager>().StopPlayerControls();
                        // staminaSlider.SetActive(true);
                        carnivalGames.GetComponent<CarnivalGamesManager>().RestartStrengthTest();
                        //  CarnivalGameRules.RingTossInProgress = true;
                        player.GetComponent<StrengthTest>().enabled = true;
                        player.GetComponent<StrengthTest>().numOfClicks = 0;

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
