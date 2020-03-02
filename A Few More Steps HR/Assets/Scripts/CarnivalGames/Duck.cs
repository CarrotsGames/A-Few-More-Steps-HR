using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public float speed;
    public float points;
    public GameObject spawner;
    Vector3 defPositon;
    // Start is called before the first frame update
    void Start()
    {
        defPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(!gameObject.GetComponent<Renderer>().enabled)
        {
            Debug.Log("DeadAndGone");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.position = spawner.transform.position ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.transform.tag == "Bullet")
        {
           gameObject.GetComponent<Renderer>().enabled = false;
            CarnivalGameRules.duckScore += points;
        }
    }
}
