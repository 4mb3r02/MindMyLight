using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public string test;
    public bool JumpKeyWasPressed;
    public bool leftOrRight;
    public enum MovementDirection { IDLE, RIGHT, LEFT };
    public MovementDirection movementDirection = MovementDirection.IDLE;

    // It needs to have a way to change it in unity depending on the level
    // I'll let you do that, I have kinda an idea but I don't want to touch your code to much
    

    public Vector3 topRightLimit;
    public Vector3 bottomLeftLimit;


    public void MovementController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyWasPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movementDirection = MovementDirection.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            movementDirection = MovementDirection.LEFT;
        }

    }

    public virtual void Moving(Rigidbody rigidbody, float speed)
    {

    }

    public virtual void Jump(Rigidbody rigidbody, Transform transform, LayerMask playerMask) { 

    }





}
