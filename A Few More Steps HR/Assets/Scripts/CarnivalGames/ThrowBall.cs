using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//USED FOR DUNK TANK MINI GAME
public class ThrowBall : MonoBehaviour
{
     public GameObject camera;
     public GameObject ballSpawner;
     public float force;
     public Slider forceSlider;
     bool  checkGameOver;
    private GameObject carnivalGamesObj;
    private CarnivalGamesManager carnivalGameManager;
    // Start is called before the first frame update
    void Start()
    {
        carnivalGamesObj = GameObject.Find("CarnivalGamesManager");
        carnivalGameManager = carnivalGamesObj.GetComponent<CarnivalGamesManager>();
        checkGameOver = false;
     }

    // Update is called once per frame
    void Update()
    {
        if (checkGameOver)
        {
            int lastRing = ballSpawner.transform.childCount - 1;
            GameObject go = carnivalGameManager.ballSpawner.transform.GetChild(lastRing).gameObject;
            // GameObject go = carnivalGameManager.throwableSpawner.transform.GetChild(CarnivalGamesManager.index - 1).gameObject;
            // Debug.Log(go.GetComponent<Rigidbody>().velocity);
            if (go.GetComponent<Rigidbody>().IsSleeping())
            {
                // dunkTank win is located in Ball script because it needs to check collision
                carnivalGameManager.DunkTankGameover("lose");
                checkGameOver = false;
                //CarnivalGamesManager.startRingToss = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            carnivalGameManager.RestartDunkTank();
        }
        if (CarnivalGamesManager.startDunkGame)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (force < 5)
                {

                    force += 0.05f;
                    forceSlider.value = force;
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (CarnivalGamesManager.index < ballSpawner.transform.childCount)
                {
                    ////resets velocity carried on the ring
                    ballSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                    //// Transports ring to players position + y ands x offset to appear in front
                    ballSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position = transform.position;
                    ballSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position += transform.forward * 1;
                    ////enables ring
                    ballSpawner.transform.GetChild(CarnivalGamesManager.index).gameObject.SetActive(true);
                    //// Adds up and forward force to give a throwing feel. 
                    ballSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(camera.transform.forward * force * 300);

                    //// Marks ring as thrown
                    CarnivalGamesManager.index++;
                    ////resets force value and slider
                    force = 0;
                    forceSlider.value = force;

                }
                if (CarnivalGamesManager.index >= ballSpawner.transform.childCount)
                {
                    checkGameOver = true;
                }
            }
        }
    }
}
