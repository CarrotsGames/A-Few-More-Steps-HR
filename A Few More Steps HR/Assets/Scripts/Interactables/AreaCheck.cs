using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    [Header("FDFC is only used in house scenes")]
    public GameObject finalDoorFpsCam;
    private GameObject cutsceneFade;
    public GameObject finalDoorGo;    
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;

    private void Start()
    {
      
       objectiveManager = GameObject.Find("ObjectiveManager");
       objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();
       cutsceneFade = GameObject.Find("ScreenFade");
       
    }
    private void OnTriggerEnter(Collider other)
    {
        objectiveManager.GetComponent<ObjectiveManager>().currentArea = other.name;
        if (other.tag == "FinalDoor")
        {
            MouseLook.canLook = false;
            PlayerMovement.stopMovement = true;

            if (finalDoorGo == null)
            {
                Debug.LogError("FinalDoorCam not assigned");
            }
            StartCoroutine(OpeningFinalDoor(other.gameObject));

        }
        else
        {
            objectiveManager.GetComponent<ObjectiveManager>().Objective();
        }
    }
    public IEnumerator OpeningFinalDoor(GameObject finalDoor)
    {
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        yield return new WaitForSeconds(0.35f);
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();

        finalDoorGo.transform.GetChild(0).gameObject.SetActive(true);
        finalDoorFpsCam.SetActive(true);
        finalDoorGo.GetComponent<Animator>().SetBool("OpenFinalDoor", true);
        yield return new WaitForSeconds(2);
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        yield return new WaitForSeconds(0.5f);
        objectiveManagerScript.itemCollected++;
        objectiveManagerScript.Objective();
    }
}
