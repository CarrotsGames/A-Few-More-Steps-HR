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
    private GameObject carnivalGameRulesGameObj;
    private CarnivalGameRules carnivalGameRules;
    private void Start()
    {
        carnivalGameRulesGameObj = GameObject.Find("CarnivalGameRules");
        carnivalGameRules = carnivalGameRulesGameObj.GetComponent<CarnivalGameRules>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
           {
             carnivalGameRules.RestartRingToss();
           }
            // if player holds down mouse 1 it increased throw force
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
            if (CarnivalGameRules.index < ringSpawner.transform.childCount)
            {
                //resets velocity carried on the ring
                ringSpawner.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                // Transports ring to players position + y ands x offset to appear in front
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.position = transform.position + transform.up * 1;
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.position += transform.forward * 1;
                // resets rotation to avoid throwing rotated ring
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.rotation = Quaternion.Euler(0, 0, 0);
                //enables ring
                ringSpawner.transform.GetChild(CarnivalGameRules.index).gameObject.SetActive(true);
                // Adds up and forward force to give a throwing feel. 
                ringSpawner.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.forward * force * 100);
                ringSpawner.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.up * force * 50);
                // Marks ring as thrown
                CarnivalGameRules.index++;
                //resets force value and slider
                force = 0;
                forceSlider.value = force;

            }

        }
    }
    
}
