using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RingToss : MonoBehaviour
{
    
    [SerializeField]
    private float force = 5;
    public GameObject ringSpawner;
    public Slider forceSlider;
    public GameObject camera;
    private GameObject player;
    private GameObject carnivalGamesObj;
    private CarnivalGamesManager carnivalGameManager;
    private bool checkGameOver;
    private void Start()
    {
        checkGameOver = false;
        carnivalGamesObj = GameObject.Find("CarnivalGamesManager");
        carnivalGameManager = carnivalGamesObj.GetComponent<CarnivalGamesManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (checkGameOver)
        {
            int lastRing = ringSpawner.transform.childCount - 1;
            GameObject go = carnivalGameManager.throwableSpawner.transform.GetChild(lastRing).gameObject;
           // GameObject go = carnivalGameManager.throwableSpawner.transform.GetChild(CarnivalGamesManager.index - 1).gameObject;
           // Debug.Log(go.GetComponent<Rigidbody>().velocity);
            if (go.GetComponent<Rigidbody>().IsSleeping())
            {
                carnivalGameManager.RingTossGameover();
                checkGameOver = false;
                //CarnivalGamesManager.startRingToss = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))  
        {

            carnivalGameManager.RestartRingToss();       
        }
        if (CarnivalGamesManager.startRingToss)
        {
            // if player holds down mouse 1 it increased throw force

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (force < 5)
                {
                    force += 0.05f * Time.deltaTime * 100;
                    forceSlider.value = force;
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (CarnivalGamesManager.index < ringSpawner.transform.childCount)
                {
                    //resets velocity carried on the ring
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                    // Transports ring to players position + y ands x offset to appear in front
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position = transform.position;
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position += transform.up / 3f;
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position += transform.forward * 0.5f;
                    // resets rotation to avoid throwing rotated ring
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.rotation = Quaternion.Euler(0, 0, 0);
                    //enables ring
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).gameObject.SetActive(true);
                    // Adds up and forward force to give a throwing feel. 
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(camera.transform.forward * force * 100);
                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(camera.transform.up * force * 50);
                    // Marks ring as thrown
                    CarnivalGamesManager.index++;
                    //resets force value and slider
                    force = 0;
                    forceSlider.value = force;

                }
                if (CarnivalGamesManager.index >= ringSpawner.transform.childCount)
                {
                    checkGameOver = true;
                }
            }
        }
                
    }
   
}


////resets velocity carried on the ring
//ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

//// Transports ring to players position + y ands x offset to appear in front
//ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position = transform.position;
//                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position += transform.up / 3f;

//                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.position += transform.forward* 0.5f;
//                    // resets rotation to avoid throwing rotated ring
//                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).transform.rotation = Quaternion.Euler(0, 0, 0);
//                    //enables ring
//                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).gameObject.SetActive(true);
//                    // Adds up and forward force to give a throwing feel. 
//                    ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(camera.transform.forward* force * 100);
//ringSpawner.transform.GetChild(CarnivalGamesManager.index).GetComponent<Rigidbody>().AddForce(camera.transform.up* force * 50);
//// Marks ring as thrown
//CarnivalGamesManager.index++;
//                    //resets force value and slider
//                    force = 0;
//                    forceSlider.value = force;