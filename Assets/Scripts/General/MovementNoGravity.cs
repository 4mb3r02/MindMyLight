using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoGravity : Movement
{
    public override void Moving(Rigidbody rigidbody, float speed)
    {
        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
    }
}
