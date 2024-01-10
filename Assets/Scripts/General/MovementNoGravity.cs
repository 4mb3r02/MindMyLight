using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementNoGravity : Movement
{
    public override void Moving(Rigidbody rigidbody, float speed)
    {
        if (border == null) return;

        border.BorderCollition(rigidbody, bottomLeftLimit, topRightLimit);
        rigidbody.useGravity = false;

        rigidbody.velocity = new Vector3(border.input.x * speed, border.input.y * speed, 0);
    }
}
