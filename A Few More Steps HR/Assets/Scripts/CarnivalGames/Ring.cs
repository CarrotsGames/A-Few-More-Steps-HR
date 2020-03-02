using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [HideInInspector]
    public bool hasRing = false;
    public int score = 150;
 
    private void OnTriggerEnter(Collider other)
    {
        if (!hasRing)
        {
            if (other.tag == "Ring")
            {
                hasRing = true;
                this.tag = "Untagged";
                CarnivalGameRules.ringScore += score;
            }
        }
       
    }
}
