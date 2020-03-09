using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    // eventname is set in inspector
    [Header("Cutscene,  Sounds, Dialogue, Action")]
    public string eventName;
    
    public AudioClip[] natureSounds;
    // random peices of dialogue the player may say at points
    public AudioClip dialogue;
    // Sets gameobject to be destroyed
    private bool destroy;
    // audiosource of this gameobject 
    private AudioSource source;
    private GameObject player;
    // allows gameobject to remain active once triggered
    public bool debugging;
    private void Start()
    {
        destroy = false;
        source = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (eventName)
            {
                case "Cutscene":
                    PlayCutscene();
                    break;
                case "Sounds":
                    PlaySoundEvent();
                    break;
                case "Dialogue":
                    PlayDialogue();
                    break;
                case "Action":
                    Action();
                    break;
            }
        }
    }
    private void Update()
    {
        // destorys the event once sound is done
        if (!source.isPlaying && destroy)
        {
            DestroyMe();
        }
        // ADD CHECKER FOR WHEN ANIMATION IS OVER
            // WHEN OVER PLAYER CAN MOVE AGAIN

    }
    // This void will hold animation properties and change lighting 
    // to inform the player that gameplay will shift into cutscene.
    void PlayCutscene()
    {
        // REMOVE ANY UI ON SCREEN
        
        // PLAY ANIM

        // TURN DOWN LIGHTING
        Debug.Log("PlayCutscene");

    }
    // purpose of this is to play nature sounds, house setting or music
    void PlaySoundEvent()
    {
        Debug.Log("SoundEffects");
        // Gets sounds between 1 and x and plays
        int index = Random.Range(0, natureSounds.Length);
        source.clip = natureSounds[index];
        source.Play();
        // disables box collider to avoid triggering sound again
        GetComponent<BoxCollider>().enabled = false;
        destroy = true;
    }
   
    // Plays first person animations such as pick up, falling etc
    void Action()
    {
        Debug.Log("Action");
        // ADD ANIMATION HERE
        // DISABLE PLAYER CONTROLS AND CAMERA
        // GO TO UPDATE FUNCTION
    }
    void PlayDialogue()
    {
        source.clip = dialogue;
        source.Play();
        Debug.Log("PlayDialogue");
    }
    void DestroyMe()
    {
        // destroys gameobject
        if (!debugging)
        {
            Destroy(this.gameObject);
        }
    }
}
