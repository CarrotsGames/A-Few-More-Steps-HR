using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
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
    // cutscenes
    void PlayCutscene()
    {
        Debug.Log("PlayCutscene");

    }
    // nature sounds or other
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
    // player talking 
    void PlayDialogue()
    {
        source.clip = dialogue;
        source.Play();
        Debug.Log("PlayDialogue");
    }
    // Player slipping , climbing etc
    void Action()
    {
        Debug.Log("Action");
        // ADD ANIMATION HERE
        // DISABLE PLAYER CONTROLS AND CAMERA
        // GO TO UPDATE FUNCTION
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
