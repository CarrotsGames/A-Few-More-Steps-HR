using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarnivalGameRules : MonoBehaviour
{
    public static int index = 0;
    public Text totalRingScore;
    public Text totalDuckScore;
    public Text totalMoleScore;
    public Text totalShotsFired;
    
    [Header("RingToss game")]
    public int numberOfThrowables;
    [Header("Add rings here!")]
    public GameObject throwables;
    public GameObject bullets;
  
    [Header ("duck shooting game")]
    public int numberOfBullets;
    public float shootTimer;
    private float timeStore;
    public GameObject rifle;
    public GameObject[] fastDuck;
    public GameObject[] normalDuck;
    public GameObject[] slowDucks;  

    [Header("Add Spawner here!")]
    public GameObject throwableSpawner;
    public GameObject bulletSpawner;
   
    public static float ringScore;
    public static float duckScore;
    public static float score;
    public static bool duckGameInProgress;
    public static bool RingTossInProgress;

    public GameObject[] throwableReceivers;
    private IEnumerator coroutine;
    public static int shotsFired;
    public static bool resetMat;
    int test;
    bool spawnMoreDucks;
    private void Start()
    {
        timeStore = shootTimer;
        totalDuckScore.text = "" + 0;
        totalRingScore.text = "" + 0;
        totalShotsFired.text = "" + 0;
        shotsFired = numberOfBullets;
        for (int i = 0; i < numberOfThrowables; i++)
        {     
            GameObject Go =  Instantiate(throwables, throwableSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = throwableSpawner.transform;
        }
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject Go = Instantiate(bullets, bulletSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = bulletSpawner.transform;
            Go.SetActive(false);
        }
     //   StartCoroutine(SpawnDuck());

    }
    private void Update()
    {
        totalRingScore.text = "" + ringScore;
        totalDuckScore.text = "" + duckScore;
        totalShotsFired.text = "" + shotsFired;

        if (Input.GetKeyDown(KeyCode.R) )
        {
            RestartDuckGame();
        }
        else if (Input.GetKeyDown(KeyCode.R) && RingTossInProgress)
        {
            RestartRingToss();
        }
                    
        if(shotsFired <= 0)
        {
            duckGameInProgress = false;
            shootTimer = timeStore;
        }
        
    }
       
 
 
    public void RestartRingToss()
    {
        for (int i = 0; i < throwableSpawner.transform.childCount; i++)
        {
            Debug.Log("ReloadRings");
            throwableSpawner.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
            throwableSpawner.transform.GetChild(i).gameObject.SetActive(false);
             
        }
        for (int i = 0; i < throwableReceivers.Length; i++)
        {
            throwableReceivers[i].GetComponent<Ring>().hasRing = false;
        }
        ringScore = 0;
        index = 0;
    }
    public void RestartDuckGame()
    { 
        for (int i = 0; i < bulletSpawner.transform.childCount; i++)
        {
            Debug.Log("Reload bullets");
            bulletSpawner.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
            bulletSpawner.transform.GetChild(i).gameObject.SetActive(false);
            bulletSpawner.transform.GetChild(i).transform.rotation = Quaternion.Euler(0, 0, 0);
            duckGameInProgress = true;
        }
         
         int length = fastDuck.Length + slowDucks.Length + normalDuck.Length;
         for (int i = 0; i < length; i++)
         {
             if(fastDuck.Length > i)
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
        index = 0;
        test = 0;
        duckScore = 0;
       
        shotsFired = numberOfBullets;

    }
    public IEnumerator SpawnDuck()
    {
        int length = fastDuck.Length + slowDucks.Length;
        for (int i = 0; i < length; ++i)
        {
            if (i < slowDucks.Length)
            {
                slowDucks[i].SetActive(true);
 
                test++;
                Debug.Log("DuckSpawned");
            }
            yield return new WaitForSeconds(0.75f);
            if (i < fastDuck.Length)
            {
                fastDuck[i].SetActive(true);

                test++;
                Debug.Log("DuckSpawned");
            }
        }
   
    }
}
