using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public string test;
    public bool JumpKeyWasPressed;

    public float speed = 6f;

    public Vector3 topRightLimit;
    public Vector3 bottomLeftLimit;


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
