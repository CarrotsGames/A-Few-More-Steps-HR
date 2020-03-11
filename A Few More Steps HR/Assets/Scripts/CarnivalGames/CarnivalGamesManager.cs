using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarnivalGamesManager : MonoBehaviour
{
    public static int index = 0;
    public Text totalRingScore;
    public Text totalDuckScore;
    //public Text totalMoleScore;
    public Text totalShotsFired;
    public Text totalStrength;
    [Header("Dunk tank game")]
    public int numberOfBalls;
    private int ballStore;

    public GameObject balls;

    [Header("Strenth game")]
    public float strenthTimer;
    public int strengthScore;
    public int strengthWinningScore;
    [HideInInspector]
    public float strengthTimeStore;

    [Header("RingToss game")]
    public float ringtossWinningScore;
    public int numberOfThrowables;     
    public GameObject rings;
    public GameObject[] throwableReceivers;

    [Header("duck shooting game")]
    public int numberOfBullets;
    public int duckWinningScore = 20;
    public GameObject rifle;
    public GameObject bullets;
    public GameObject[] fastDuck;
    public GameObject[] normalDuck;
    public GameObject[] slowDucks;
    private float timeStore;

    [Header("Add Spawner here!")]
    public GameObject throwableSpawner;
    public GameObject bulletSpawner;
    public GameObject ballSpawner;

    public static float ringScore;
    public static float duckScore;
    public static float score;
    public static bool duckGameInProgress;
    public static bool startRingToss;
    public static bool startStrengthTest;
    public static bool startDunkGame;

    public static int shotsFired;
    public static bool resetMat;
    private IEnumerator coroutine;
    private GameObject objectiveManager;

     private void Start()
    {
        ballStore = numberOfBalls;
        startStrengthTest = false;
        startRingToss = false;
        startDunkGame = false;
        strengthTimeStore = strenthTimer;
        totalDuckScore.text = "" + 0;
        totalRingScore.text = "" + 0;
        totalShotsFired.text = "" + 0;
        totalStrength.text = "" + 0;
        shotsFired = numberOfBullets;
        objectiveManager = GameObject.Find("ObjectiveManager");
        // creates all throwables before scene starts to avoid instantiate stutter
        for (int i = 0; i < numberOfThrowables; i++)
        {
            GameObject Go = Instantiate(rings, throwableSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = throwableSpawner.transform;
            Go.SetActive(false);
        }
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject Go = Instantiate(bullets, bulletSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = bulletSpawner.transform;
            Go.SetActive(false);
        }
        for (int i = 0; i < numberOfBalls; i++)
        {
            GameObject Go = Instantiate(balls, ballSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = ballSpawner.transform;
            Go.SetActive(false);
        }
    }
    private void Update()
    {
        // dislays all game texts
        totalRingScore.text = "" + ringScore;
        totalDuckScore.text = "" + duckScore;
        totalShotsFired.text = "" + shotsFired;
        totalStrength.text = "" + strengthScore;     
  
    }
    public void RestartDunkTank()
    {
        startDunkGame = true;
        numberOfBalls = ballStore;
        index = 0;
    }
    // this game is done like this because results can
    //be found in two scripts
    public void DunkTankGameover(string results)
    {
        startDunkGame = false;
        if(results == "win")
        {
            objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
            objectiveManager.GetComponent<ObjectiveManager>().Objective();

            Debug.Log("WIN");
        }
        else
        {
            Debug.Log("LOST");
        }
   
        Debug.Log("GAMEOVER");
    }
  // Strength test rules
    public void RestartStrengthTest()
    {
        // resets timer and score
        strenthTimer = strengthTimeStore;
        strengthScore = 0;
        startStrengthTest = true;
    }
    public void StrenthTestGameover()
    {
        if(strengthScore >= strengthWinningScore)
        {
            objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
            objectiveManager.GetComponent<ObjectiveManager>().Objective();

            Debug.Log("YOU WIN");
        }
        else if (strengthScore < strengthWinningScore)
        {
            Debug.Log("YOU LOSE");
        }
        startStrengthTest = false;
    }
    public void RingTossGameover()
    {
        if(ringScore >= ringtossWinningScore)
        {
            objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
            objectiveManager.GetComponent<ObjectiveManager>().Objective();
            Debug.Log("You win");
        }
        else if (ringScore < ringtossWinningScore)
        {
            Debug.Log("You lose");
        }
        startRingToss = false;
    }
    public void RestartRingToss()
    {
        for (int i = 0; i < throwableSpawner.transform.childCount; i++)
        {
            Debug.Log("ReloadRings");
            // Retreives all thrown rings, disables them and moves them to pos 0,0,0
            throwableSpawner.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
            throwableSpawner.transform.GetChild(i).gameObject.SetActive(false);

        }
        for (int i = 0; i < throwableReceivers.Length; i++)
        {
            // tells the poles to accept ring score
            throwableReceivers[i].GetComponent<Pole>().hasRing = false;
        }
        startRingToss = true;
        // resets rings score and list ind  ex
        ringScore = 0;
        index = 0;
    }
    // Duck game Properties
    public void DuckGameOver()
    {
        if (duckScore >= duckWinningScore)
        {
            objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
             objectiveManager.GetComponent<ObjectiveManager>().Objective();

            Debug.Log("You win");
        }
        else
        {
            Debug.Log("You lose");
        }
        

    }
    public void RestartDuckGame()
    {
        for (int i = 0; i < bulletSpawner.transform.childCount; i++)
        {
            // Retreives all bullets, disables them and moves them to pos 0,0,0
            Debug.Log("Reload bullets");
            bulletSpawner.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
            bulletSpawner.transform.GetChild(i).gameObject.SetActive(false);
            bulletSpawner.transform.GetChild(i).transform.rotation = Quaternion.Euler(0, 0, 0);
            duckGameInProgress = true;
        }

        int length = fastDuck.Length + slowDucks.Length + normalDuck.Length;
        for (int i = 0; i < length; i++)
        {
            if (fastDuck.Length > i)
            {
                fastDuck[i].GetComponent<Renderer>().enabled = true;
                fastDuck[i].GetComponent<Duck>().hasBeenHit = false;
            }
            if (slowDucks.Length > i)
            {
                slowDucks[i].GetComponent<Renderer>().enabled = true;
                slowDucks[i].GetComponent<Duck>().hasBeenHit = false;
            }
            if (normalDuck.Length > i)
            {
                normalDuck[i].GetComponent<Renderer>().enabled = true;
                normalDuck[i].GetComponent<Duck>().hasBeenHit = false;
            }
        }
        rifle.SetActive(true);
        // resets all values
        index = 0;
        duckScore = 0;
        shotsFired = numberOfBullets;
    }
}
 
  
