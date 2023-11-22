using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoAnimation : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    bool checkColl;

    void Update()
    {
        // If i'm touching the wall I start the movement
        if(checkColl == true)
        {
            GoClose();
        }
    }
    public void Collision(Collider other)
    {
        // Layer 6 = Tree
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Im touching the tree");
            checkColl = true;
            // Animation aproach beggins

            // Conversation beggins
            Conversation();
            // Figure how to pass from a dialoge to anotherone
            PassConversation();
            // Change of scene between the 1ºPhase to the 2ºPhase
            ChangeScene();
        }
    }

   

    public void GoClose()
    {
        // Player can't move

        Debug.Log("I'm moving to the objective!");

        Vector3 PosA = transform.position;
        Vector3 PosB = target.position;

        // Moves gradually the player from it's position to a position B
        transform.position = Vector3.Lerp(PosA, PosB, moveSpeed * Time.deltaTime);

        if(Math.Abs(PosA.x - PosB.x) < 0.1 )
        {
            checkColl = false;
            Debug.Log("Im free!");

        }
    }

    private void Conversation()
    {

    }

    private void PassConversation()
    {

    }

    private void ChangeScene()
    {

    }
}
