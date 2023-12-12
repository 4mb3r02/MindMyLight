using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DELETE THE COMENTS WHEN YOU HAVE IT CLEAR, THEY ARE JUST FOR NOT BURNING YOUR BRAIN ;)

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask playerMask;

    public bool gravity;
    public Movement movement;
    public new AutoAnimation animation;
    public AudioManager manager;

    public EndScreen endScreen;
    private Rigidbody rigidbodyComponent;
    private bool canMove = true;
    private bool canJump = true;
    static int lives = 3;

    public float speed = 6f;


    // Start is called before the first frame update
    void Start()
    {
        
            //gameObject.AddComponent(typeof(EndScreen)) as EndScreen;
        rigidbodyComponent = GetComponent<Rigidbody>();
        if (gravity == false)
        {
            movement = gameObject.AddComponent(typeof(MovementNoGravity)) as MovementNoGravity;
        } else
        {
            movement = gameObject.AddComponent(typeof(MovementGravity)) as MovementGravity;
        }

        // Finds the object that doesn't die from the first scene
        GameObject oldObject = GameObject.Find("AudioManager");

        if (oldObject != null)
        {
            // Access the script of the persistant object and asigns the component
            AudioManager oldScript = oldObject.GetComponent<AudioManager>();

            if (oldScript != null)
            {
                manager = oldScript;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.MovementController();
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            movement.Jump(rigidbodyComponent, groundCheck, playerMask);
        }

        if (canMove)
        {
            movement.Moving(rigidbodyComponent, speed);
        }
    }

    // For the animation
    private void OnTriggerEnter(Collider other)
    {
        if (animation != null)
        {

            animation.Collision(other);
        }
        else
        {
            Debug.Log("Im not finding the script, animation is null. Try to add the player Script to animation");
        }

        if (manager != null)
        {
            manager.TouchColliderSoundf(other);
        }
        else
        {
           Debug.Log("Im not finding the script, manager is null.");
        }

   }



    public void TakeDamage()
    {
        //EndScreen endScreen = GetComponent<EndScreen>();
        //Debug.Log("Amound of lives:" + lives);
        Debug.Log(EndScreen.instance);
        lives = lives - 1;
        //set model ( array )
        
        if (lives <= 0)
        {
            EndScreen.instance.TurnOnDeathScreen();
            
            //Destroy(gameObject);
            //Destroy(rigidbodyComponent);//get game over screen;
        }

    }

    public void AllowMovement() {canMove = true;}
    public void BlockMovement() {canMove = false;}
    public void AllowJump() {canJump = true;}
    public void BlockJump() {canJump = false;}
}
