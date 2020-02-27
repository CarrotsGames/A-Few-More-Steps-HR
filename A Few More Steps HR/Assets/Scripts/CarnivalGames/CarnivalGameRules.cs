using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CarnivalGameRules : MonoBehaviour
{
    public static int index = 0;
    public Text totalScore;
    public int numberOfThrowables;   
    [Header("Add Spawner here!")]
    public GameObject throwableSpawner;
    [Header("Add rings or basketbals here!")]
    public GameObject throwables;
    public static float score;
    public GameObject[] throwableReceivers;
    private void Start()
    {
   
        totalScore.text = "" + 0;
        for (int i = 0; i < numberOfThrowables; i++)
        {     
            GameObject Go =  Instantiate(throwables, throwableSpawner.transform.position, Quaternion.identity);
            Go.transform.parent = throwableSpawner.transform;
        }
    }
    private void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadRings();
        }
        totalScore.text = "" + score;
    }
    public void ReloadRings()
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
        score = 0;
        index = 0;
    }
}
