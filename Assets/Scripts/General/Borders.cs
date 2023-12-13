using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Borders : MonoBehaviour
{
    public Vector2 input;
    public void BorderCollition(Rigidbody rigidbody, Vector3 cornerBottomLeft, Vector3 cornerTopRight)
    {
        input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));

        if ((rigidbody.position.x <= cornerBottomLeft.x && input.x == -1) || (rigidbody.position.x >= cornerTopRight.x && input.x == 1))
        {
            input.x = 0;
        }

        if ((rigidbody.position.y <= cornerBottomLeft.y && input.y == -1) || (rigidbody.position.y >= cornerTopRight.y && input.y == 1))
        {
            input.y = 0;
        }
    }

    public bool BorderCollitionEnemy(Rigidbody rigidbody, Vector3 cornerBottomLeft, Vector3 cornerTopRight, bool rotationDone)
    {
        input = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
        

        if (((rigidbody.position.x <= cornerBottomLeft.x) || (rigidbody.position.x >= cornerTopRight.x)) && rotationDone)
        {
            return true;
            
        }
        else if (((rigidbody.position.y <= cornerBottomLeft.y) || (rigidbody.position.y >= cornerTopRight.y)) && rotationDone)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }

}
