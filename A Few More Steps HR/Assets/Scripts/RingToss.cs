using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingToss : MonoBehaviour
{
    int index = 0;
    [SerializeField]
    private float force = 5;
    public GameObject[] rings;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadRings();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (force < 5)
            {
                force += 0.05f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (index <= rings.Length)
            {
                rings[index].transform.position = transform.position + transform.up * 1;
                rings[index].transform.position += transform.forward * 1;

                rings[index].SetActive(true);
                rings[index].GetComponent<Rigidbody>().AddForce(transform.forward * force * 100);
                rings[index].GetComponent<Rigidbody>().AddForce(transform.up * force * 100);
                index++;
                force = 0;
            }
        }
    }
    void ReloadRings()
    {
        for (int i = 0; i < rings.Length; i++)
        {
            Debug.Log("ReloadRings");
            rings[i].transform.position = new Vector3(0, 0, 0);
            rings[i].SetActive(false);

        }
        index = 0;
    }
}
