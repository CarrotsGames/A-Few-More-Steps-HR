using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9f;
    public float groundDist = 0.4f;
    public static bool stopMovement;
    public Transform groundCheck;
    public LayerMask groundMask;

    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public bool canMove;
    [SerializeField]
    public static bool isSwimming;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        stopMovement = false;
        canMove = true;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            Movement();
        }
    }
    void Movement()
    {
        // Checks if grounded
        // (can be used for jumping but is currently used to stop adding y velocity when grounded..)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (!isGrounded && velocity.y < 0)
        {
            velocity.y = -6;
        }
        // Gets movement using WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //   Vector3 forwardDir = Vector3.ProjectOnPlane(transform.forward, groundCheck.position).normalized;

        // movement 
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * speed * Time.deltaTime);

        // gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
   
}
