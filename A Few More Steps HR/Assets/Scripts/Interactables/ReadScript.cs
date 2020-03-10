using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Equips to cameraCM
public class ReadScript : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Book");
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,5, mask))
        {
            Debug.Log("in range");
            reticle.HighliteObject();
          // if (hit.transform.tag == "Book")
          // {
                if (Input.GetKey(KeyCode.E))
                {
                    hit.transform.gameObject.GetComponent<Notes>().ReadNote();
                }
           // }
        }
        else
        {
            reticle.disableHighlite();

        }
    }
}
