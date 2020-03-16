using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed = 75;
    public GameObject camera;
    public LayerMask duckMask;
    public GameObject bulletSpawer;
    private GameObject carnivalGamesObj;
    private CarnivalGamesManager carnivalGameManager;
    public GameObject barrel;
    private void Start()
    {
        bulletSpeed *= 10;
        carnivalGamesObj = GameObject.Find("CarnivalGamesManager");
        carnivalGameManager = carnivalGamesObj.GetComponent<CarnivalGamesManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            carnivalGameManager.RestartDuckGame();           
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            carnivalGameManager.rifle.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (CarnivalGamesManager.index < bulletSpawer.transform.childCount)
            {
                TakenShot();
                // resets velocity
                bulletSpawer.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                // transports bullet to players pos 
                bulletSpawer.transform.GetChild(CarnivalGamesManager.index).transform.position += barrel.transform.position;
                bulletSpawer.transform.GetChild(CarnivalGamesManager.index).transform.position += barrel.transform.forward;
                // enables rifle
                bulletSpawer.transform.GetChild(CarnivalGamesManager.index).gameObject.SetActive(true);

                // shoots bullet using forward force
                bulletSpawer.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed);
                //bulletSpawer.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.up * force * 50);
                CarnivalGamesManager.index++;
            }
            // You just fixed the force issue now add scoring 
        }
    }
    public void TakenShot()
    {
        CarnivalGamesManager.shotsFired -= 1;
        if (CarnivalGamesManager.shotsFired <= 0)
        {
            carnivalGameManager.DuckGameOver();
        }
    }
}
