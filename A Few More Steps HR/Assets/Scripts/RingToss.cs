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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (force < 5)
            {
                force += 0.05f;
                forceSlider.value = force;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (CarnivalGameRules.index <= ringSpawner.transform.childCount)
            {
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.position = transform.position + transform.up * 1;
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.position += transform.forward * 1;
                ringSpawner.transform.GetChild(CarnivalGameRules.index).transform.rotation = Quaternion.Euler(0, 0, 0);
                ringSpawner.transform.GetChild(CarnivalGameRules.index).gameObject.SetActive(true);
                ringSpawner.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.forward * force * 100);
                ringSpawner.transform.GetChild(CarnivalGameRules.index).GetComponent<Rigidbody>().AddForce(camera.transform.up * force * 50);
                CarnivalGameRules.index++;
                force = 0;
                forceSlider.value = force;

            }
        }
    }
    //void ReloadRings()
    //{
    //    for (int i = 0; i < ringSpawner.transform.childCount; i++)
    //    {
    //        Debug.Log("ReloadRings");
    //        ringSpawner.transform.GetChild(i).transform.position = new Vector3(0, 0, 0);
    //        ringSpawner.transform.GetChild(i).gameObject.SetActive(false);

    //    }
       
    //}
}
