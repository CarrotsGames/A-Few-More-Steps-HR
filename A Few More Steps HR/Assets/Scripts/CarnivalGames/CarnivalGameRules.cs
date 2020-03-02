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
    public GameObject[] ducks;
    [Header("Add Spawner here!")]
    public GameObject throwableSpawner;
    public GameObject bulletSpawner;
    public static float ringScore;
    public static float duckScore;
    public static float score;
    public static bool duckGameInProgress;
    public GameObject[] throwableReceivers;
    
    private void Start()
    {
        timeStore = shootTimer;
        totalDuckScore.text = "" + 0;
        totalRingScore.text = "" + 0;
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
    }
    private void Update()
    {
        totalRingScore.text = "" + ringScore;
        totalDuckScore.text = "" + duckScore;
     
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartDuckGame();
        }
       
        if(duckGameInProgress)
        {
            shootTimer -= Time.deltaTime;
            if(shootTimer < 0)
            {
                duckGameInProgress = false;
                shootTimer = timeStore;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            Invoke("SpawnDuck", 0.5f);
        }
    }
    public void SpawnDuck()
    {
        Debug.Log("DuckSpawned");
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
            throwableReceivers[i].transform.tag = "Pole";
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

        }
        rifle.SetActive(true);
        index = 0;

    }
}
