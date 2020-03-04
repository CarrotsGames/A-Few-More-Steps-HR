using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameObject carnivalGamesObj;
    private CarnivalGamesManager carnivalGameManager;
    private void Start()
    {
        carnivalGamesObj = GameObject.Find("CarnivalGamesManager");
        carnivalGameManager = carnivalGamesObj.GetComponent<CarnivalGamesManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Target")
        {
            carnivalGameManager.DunkTankGameover("win");
        }
    }
}
