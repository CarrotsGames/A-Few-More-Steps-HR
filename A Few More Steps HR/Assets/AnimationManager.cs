using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//There will be times in scenes where some of these will be null which is ok 
// because some scenes dont have the required animation
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
    public GameObject babyInArms;
 
    [Header("For when the player checks on baby")]
    public GameObject bDoorOpenAnim;
    public GameObject bDoorCam;
    [Header("The baby object in the crib before animation")]
    public GameObject cribBaby;
    //Static tells player movement to play anim when player moves
    public static bool playBabyAnim;
    private GameObject cutsceneFade;
    private GameObject objectiveManager;
    private ObjectiveManager objectiveManagerScript;
    // Gets player so we can move him when cutscene ends
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (clothingArm != null)
        {
            clothingArm.SetActive(false);
        }

        if (cribArms != null)
        {
            cribArms.SetActive(false);
        }
        objectiveManager = GameObject.Find("ObjectiveManager");
        objectiveManagerScript = objectiveManager.GetComponent<ObjectiveManager>();
        cutsceneFade = GameObject.Find("ScreenFade");
        finalDoorFpsCam.SetActive(false);
        player = GameObject.Find("Player");
        playBabyAnim = false;
    }

    // Passes in animaton and object to get required animation
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
            case "PanicBabyCrib":
                //  PlayGameAnimation(2.75f);
                StartCoroutine(PlayAnimation(14f, hitObject, cribArms, cribCam));
                babyInArms.SetActive(true);
                playBabyAnim = true;
                cribBaby.SetActive(false);
                break;
            case "BabiesDoorAnim":
                //  PlayGameAnimation(2.75f);
                StartCoroutine(OpenBabyDoor(4.85f, hitObject, bDoorOpenAnim, bDoorCam));
               // cribBaby.SetActive(false);
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
        objectiveManagerScript.HideText();
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        yield return new WaitForSeconds(0.35f);
        hitGameobject.SetActive(false);

        // stops fade in
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();
    
        // enables animtions
        animCam.SetActive(true);
        animArms.SetActive(true);
   
        // Waits animation time to begin fade in / out
        yield return new WaitForSeconds(animTime);
            
        // Just in case for some reason the courintine didnt finish this makes it finish
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        yield return new WaitForSeconds(0.10f);
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
        yield return new WaitForSeconds(0.35f);
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();
     
        // adds item progress to manager
        objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
        objectiveManager.GetComponent<ObjectiveManager>().Objective();
      
        // disables animation
        animCam.SetActive(false);
        animArms.SetActive(false);

        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;
        //  pickUpArm.transform.position += new Vector3(0, -0.25f, 0);
        objectiveManagerScript.ShowText();


    }
    IEnumerator OpenBabyDoor(float animTime, GameObject hitGameobject,
       GameObject animArms, GameObject animCam)
    {
        objectiveManagerScript.HideText();
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();
      
        // Waits until screen is fully faded
        yield return new WaitForSeconds(0.35f);
      
        // begins cutscene
        hitGameobject.GetComponent<Animator>().SetBool("OpenBabyDoor", true);
      
        // stops fade in courintine
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();
      
        // enables aniamtions
        animCam.SetActive(true);
        animArms.SetActive(true);
        
        // Waits animation time to begin fade in / out
        yield return new WaitForSeconds(animTime);
      
        // Just in case for some reason the courintine didnt finish this makes it finish
        cutsceneFade.GetComponent<ScreenFade>().StopAllCoroutines();       
        yield return new WaitForSeconds(0.10f);
        cutsceneFade.GetComponent<ScreenFade>().BeginCutscene();      
        yield return new WaitForSeconds(0.35f);
        cutsceneFade.GetComponent<ScreenFade>().EndCutsceneFade();
      
        //// adds item progress to manager
        //objectiveManager.GetComponent<ObjectiveManager>().itemCollected++;
        //objectiveManager.GetComponent<ObjectiveManager>().Objective();
      
        // disables animation
        animCam.SetActive(false);
        animArms.SetActive(false);
      
        // player can move again
        MouseLook.canLook = true;
        PlayerMovement.stopMovement = false;
        objectiveManagerScript.ShowText();

    }

    // Final door anim a bit different so needs its own function
    public IEnumerator OpeningFinalDoor(GameObject finalDoor)
    {
        objectiveManagerScript.HideText();
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
       
        objectiveManagerScript.Objective();
    }
}
