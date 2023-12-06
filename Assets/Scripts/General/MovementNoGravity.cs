using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovementNoGravity : Movement
{
    Borders border = new Borders();
    public override void Moving(Rigidbody rigidbody, float speed)
    {
        border.BorderCollition(rigidbody, bottomLeftLimit, topRightLimit);
        rigidbody.useGravity = false;

        rigidbody.velocity = new Vector3(border.input.x * speed, border.input.y * speed, 0);
    }
}
