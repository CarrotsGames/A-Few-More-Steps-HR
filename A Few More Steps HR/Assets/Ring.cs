using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pole")
        {
            other.tag = "Untagged";
            CarnivalGameRules.score += 150;
        }

    }

}
