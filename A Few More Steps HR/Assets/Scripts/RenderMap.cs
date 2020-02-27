using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMap : MonoBehaviour
{
   public GameObject[] maps;

    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
 
 
    private void OnTriggerExit(Collider other)
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = player.transform.position;
        Vector3 dir = pos - targetPos;
        dir.Normalize();
        if (Vector3.Dot(dir, pos) > 1)
        {
            Debug.Log("Infront");
            maps[0].SetActive(true);
            maps[1].SetActive(false);
           
        }
        else
        {
            maps[0].SetActive(false);
            maps[1].SetActive(true);

        }
    }
}
