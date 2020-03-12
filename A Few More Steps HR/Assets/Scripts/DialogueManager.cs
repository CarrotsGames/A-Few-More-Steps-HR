using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static int part;
    public string[] gfDialogue;
    public string[] Otherdialogue;
    public string[] dialogue;

    void Conversation(string person)
    {
        switch(part)
        {
            case 1:
                if (person == "gf")
                {

                }
                if (person == "Carny")
                {

                }
                if (person == "Wife")
                {

                }
                break;

        }
    }
}
