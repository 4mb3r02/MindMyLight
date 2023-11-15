using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform groundCheckTransform = null;
    //public LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;


    // ========================================================== START ========================================================
    // Start is called before the first frame update
    void Start()
    {
        // We call it the first time so we dont have to use it over and over again
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // ========================================================== UPDATE ========================================================
    // Update is called once per frame
    void Update()
    {
        // When you press a key it does something (space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Stroopwafles"); -- Comment
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal"); // By default takes the input of (a and d)
    }

    // ========================================================== PHYSICS ========================================================
    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {

        // --------- Horizontal Movement ---------

        HorizontalMovement();

        // --------- Ground Check ---------

        // Here it checks if it's colliding with any object, the imaginarie sphere arround the player 
        //if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        //{
        //   return;
        //}


        // --------- Jump ---------

        // It's better to make the physics change in the physicUpdate loop for a better performance
        if (jumpKeyWasPressed)
        {
            Jump();
        }

    }

    // ========================================================== METHODS ========================================================
    void Jump()
    {
        //Make the player jump
        rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange); //Code to jump (changing the *7 you jump more or less)
        jumpKeyWasPressed = false;
    }

    void HorizontalMovement()
    {
        //We let the y as it was because otherwise it will conflict with the movement while jumping
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0); // We change the velocity of the axis (x,y,z)
    }

    //Method that checks if we are colliding with another object
    private void OnTriggerEnter(Collider other)
    {
        // Layer 6 = Tree
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Im touching the tree");
            // Animation aproach beggins
            // Conversation beggins
            // Figure how to pass from a dialoge to anotherone
            // Change of scene between the 1ºPhase to the 2ºPhase
        }

    }
}
