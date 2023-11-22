using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public string test;
    public bool JumpKeyWasPressed;

    // It needs to have a way to change it in unity depending on the level
    // I'll let you do that, I have kinda an idea but I don't want to touch your code to much
    public float speed = 6f;


    public void MovementController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyWasPressed = true;
        }


    }

    public virtual void Moving(Rigidbody rigidbody)
    {

    }

    public virtual void Jump(Rigidbody rigidbody, Transform transform, LayerMask playerMask) { 

    }





}
