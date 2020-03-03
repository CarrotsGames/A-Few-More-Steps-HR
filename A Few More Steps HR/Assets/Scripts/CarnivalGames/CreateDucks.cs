using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script is no longer needed
public class CreateDucks : MonoBehaviour
{
    [HideInInspector]
    public GameObject carnivalGameRules;
    private CarnivalGamesManager carnivalGameScript;
    //private int test;

    private void Start()
    {
        carnivalGameRules = GameObject.Find("CarnivalGameRules");
        carnivalGameScript = carnivalGameRules.GetComponent<CarnivalGamesManager>();
    }
    // Update is called once per frame
    public IEnumerator SpawnDuck()
    {
        int length = carnivalGameScript.fastDuck.Length + carnivalGameScript.slowDucks.Length;
        for (int i = 0; i < length; ++i)
        {
            if (i < carnivalGameScript.slowDucks.Length)
            {
                carnivalGameScript.slowDucks[i].SetActive(true);

             //   test++;
                Debug.Log("DuckSpawned");
            }
            yield return new WaitForSeconds(0.75f);
            if (i < carnivalGameScript.fastDuck.Length)
            {
                carnivalGameScript.fastDuck[i].SetActive(true);

              //  test++;
                Debug.Log("DuckSpawned");
            }
        }

    }
}
