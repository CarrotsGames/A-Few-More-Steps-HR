using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePrizes : MonoBehaviour
{
    public GameObject[] prizes;

    private bool gotPrizeA;
    private bool gotPrizeB;
    private bool gotPrizeC;

    public void GrantPrize(string prize)
    {
        switch(prize)
        {
            case "A":
                if (!gotPrizeA)
                {
                    prizes[0].SetActive(true);
                    gotPrizeA = true;
                }
                break;
            case "B":
                if (!gotPrizeB)
                {
                    prizes[1].SetActive(true);
                    gotPrizeB = true;
                }
                break;
            case "C":
                if (!gotPrizeC)
                {
                    prizes[2].SetActive(true);
                    gotPrizeC = true;
                }
                break;
        }
    }
}
