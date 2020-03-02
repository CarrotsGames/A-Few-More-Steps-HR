using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject camera;
    public LayerMask duckMask;
    public GameObject bulletSpawer;
    private GameObject carnivalGameRulesGameObj;
    private CarnivalGameRules carnivalGameRules;
    public GameObject barrel;
    private void Start()
    {
        carnivalGameRulesGameObj = GameObject.Find("CarnivalGameRules");
        carnivalGameRules = carnivalGameRulesGameObj.GetComponent<CarnivalGameRules>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
 
            carnivalGameRules.RestartDuckGame();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            carnivalGameRules.rifle.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (CarnivalGameRules.index < bulletSpawer.transform.childCount)
            {

                CarnivalGameRules.shotsFired -= 1;

                // resets velocity
                bulletSpawer.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                // transports bullet to players pos 
                bulletSpawer.transform.GetChild(CarnivalGameRules.index).transform.position += barrel.transform.position;
                bulletSpawer.transform.GetChild(CarnivalGameRules.index).transform.position += barrel.transform.forward;
                // enables rifle
                bulletSpawer.transform.GetChild(CarnivalGameRules.index).gameObject.SetActive(true);
                // shoots bullet using forward force
                bulletSpawer.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(barrel.transform.forward * 200 * Time.time);
                //bulletSpawer.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.up * force * 50);
                CarnivalGameRules.index++;
            }
            // You just fixed the force issue now add scoring 
        }
    }
}
