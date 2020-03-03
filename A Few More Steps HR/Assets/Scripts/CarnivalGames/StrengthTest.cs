using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StrengthTest : MonoBehaviour
{
    public int numOfClicks;
    public Slider strength;
    private GameObject carnivalGameRulesGameObj;
    private CarnivalGameRules carnivalGameRules;
    // Start is called before the first frame update
    void Start()
    {
        carnivalGameRulesGameObj = GameObject.Find("CarnivalGameRules");
        carnivalGameRules = carnivalGameRulesGameObj.GetComponent<CarnivalGameRules>();

        // strength.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        strength.value = numOfClicks;

        if (Input.GetKeyDown(KeyCode.R))
        {
            
            numOfClicks = 0;
            carnivalGameRules.RestartStrengthTest();
        }
        carnivalGameRules.strenthTimer -= Time.deltaTime;
        Debug.Log(carnivalGameRules.strenthTimer);
        if (carnivalGameRules.strenthTimer > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                numOfClicks += 1;
              //  carnivalGameRules.strengthScore = numOfClicks;
            }
        }
        else
        {
            carnivalGameRules.strengthScore = numOfClicks;
            Debug.Log("Gameover");
        }
    }
}
