using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("Used for picking clothes from closet")]
    public GameObject clothingArm;
    public GameObject clothingCam;
    [Header("Camera for final door (only in houseScenes)")]
    public GameObject finalDoorGo;
    public GameObject finalDoorFpsCam;
    [Header("For when the player picks up baby in crib")]
    public GameObject cribArms;
    public GameObject cribCam;
    [Header("The baby object in the crib before animation")]
    public GameObject cribBaby;
    private GameObject cutsceneFade;
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        if (clothingArm != null)
        {
            clothingArm.SetActive(false);
        }
        objectiveManager = GameObject.Find("ObjectiveManager");
        objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();
        cutsceneFade = GameObject.Find("ScreenFade");
        finalDoorFpsCam.SetActive(false);
    }

    
    public void AnimationName(string animName, GameObject hitObject)
    {
        switch (animName)
        {
            case "Clothing":
                //  PlayGameAnimation(2.75f);
                StartCoroutine(PlayAnimation(2.75f, hitObject, clothingArm, clothingCam));
                break;
            case "BabyCrib":
                //  PlayGameAnimation(2.75f);
                StartCoroutine(PlayAnimation(5.15f, hitObject, cribArms, cribCam));
                cribBaby.SetActive(false);
                break;
            case "FinalDoor":
                //  PlayGameAnimation(2.75f);
                StartCoroutine(OpeningFinalDoor(hitObject));
                break;
        }
    }
    // void that takes animation times ( how long anim will last ) 

    IEnumerator PlayAnimation(float animTime, GameObject hitGameobject, 
        GameObject animArms, GameObject animCam)
    {
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();

        yield return new WaitForSeconds(0.35f);
        hitGameobject.SetActive(false);
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();

        animCam.SetActive(true);
        animArms.SetActive(true);


        yield return new WaitForSeconds(animTime);
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        yield return new WaitForSeconds(0.10f);
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        yield return new WaitForSeconds(0.35f);
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();
        // adds item progress to manager
        objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
        objectiveManager.GetComponent<ObjectiveManager>().Objective();
        animCam.SetActive(false);
        animArms.SetActive(false);

        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;
        //  pickUpArm.transform.position += new Vector3(0, -0.25f, 0);


    }
    // Final door anim a bit different so needs its own function
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
        //cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        //cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        //yield return new WaitForSeconds(0.5f);
        objectiveManagerScript.itemCollected++;
        objectiveManagerScript.Objective();
    }
}
