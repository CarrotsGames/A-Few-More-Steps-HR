using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StrengthTest : MonoBehaviour
{
    public int numOfClicks;
    public Slider strength;
    private GameObject carnivalGamesObj;
    private CarnivalGamesManager carnivalGamesManager;
    // Start is called before the first frame update
    void Start()
    {
        carnivalGamesObj = GameObject.Find("CarnivalGamesManager");
        carnivalGamesManager = carnivalGamesObj.GetComponent<CarnivalGamesManager>();

        // strength.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        strength.value = numOfClicks;

        if (Input.GetKeyDown(KeyCode.R))
        {
            
            numOfClicks = 0;
            carnivalGamesManager.RestartStrengthTest();
        }
        Debug.Log(carnivalGamesManager.strenthTimer);
        if (carnivalGamesManager.strenthTimer > 0)
        {
            carnivalGamesManager.strenthTimer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                numOfClicks += 1;
              //  carnivalGameRules.strengthScore = numOfClicks;
            }
        }
        else
        {
            carnivalGamesManager.strengthScore = numOfClicks;
            Debug.Log("Gameover");
        }
    }
}
