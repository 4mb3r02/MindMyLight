using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGravity : Movement
{
    public override void Jump(Rigidbody rigidbody, Transform transform, LayerMask playerMask)
    {
        if (Physics.OverlapSphere(transform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (JumpKeyWasPressed)
        {
            rigidbody.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            JumpKeyWasPressed = false;
        }


    }

    public override void Moving(Rigidbody rigidbody, float speed)
    {
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, 0);
    }


}
