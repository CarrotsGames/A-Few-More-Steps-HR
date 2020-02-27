using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(Player.GetComponent<CharacterController>(), GetComponent<Collider>());
    }

    
}
