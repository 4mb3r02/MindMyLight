using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoGravity : Movement
{
    Borders border = new Borders();
    public override void Moving(Rigidbody rigidbody, float speed)
    {
        border.BorderCollition(rigidbody, bottomLeftLimit, topRightLimit);
        rigidbody.useGravity = false;

        rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
    }
}
