using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

// DELETE THE COMENTS WHEN YOU HAVE IT CLEAR, THEY ARE JUST FOR NOT BURNING YOUR BRAIN ;)

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask playerMask;

    public bool gravity;
    public Movement movement;
    public new AutoAnimation animation;

    private Rigidbody rigidbodyComponent;
    private bool canMove = true;
    private bool canJump = true;
    public float speed;

    public GameObject topRightLimitGameobject;
    public GameObject bottomLeftLimitGameobject;

    // Start is called before the first frame update
    void Start()
    {

        rigidbodyComponent = GetComponent<Rigidbody>();
        if (gravity == false)
        {
            movement = gameObject.AddComponent(typeof(MovementNoGravity)) as MovementNoGravity;

            movement.bottomLeftLimit = bottomLeftLimitGameobject.transform.position;
            movement.topRightLimit = topRightLimitGameobject.transform.position;
        } else
        {
            movement = gameObject.AddComponent(typeof(MovementGravity)) as MovementGravity;
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

    }

    public void AllowMovement() {canMove = true;}
    public void BlockMovement() {canMove = false;}
    public void AllowJump() {canJump = true;}
    public void BlockJump() {canJump = false;}
}
