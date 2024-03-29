using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoAnimation : MonoBehaviour
{
    public Transform target;
    public Player player;
    public Rigidbody rigidbodyComponent;
    

    float moveSpeed = 0.35f;
    bool checkColl;
    public bool checkConvoFinished;
    public bool goToVillageScene;

    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // If i'm touching the wall I start the movement
        if(checkColl == true)
        {
            GoClose();
        }

        if(checkConvoFinished == true)
        {
            FlyUp();
        }

        if(goToVillageScene == true)
        {
            Debug.Log("Reach?");
            SceneManager.LoadScene("Level 2 Village");
            goToVillageScene = false;
        }
    }
    public void Collision(Collider other)
    {
        // Layer 6 = Tree
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Im touching the tree");
            checkColl = true;
        }
    }

   

    public void GoClose()
    {
        // Player can't move
        player.BlockJump();
        player.BlockMovement();

        Debug.Log("I'm moving to the objective!");

        Vector3 PosA = transform.position;
        Vector3 PosB = target.position;

        // Moves gradually the player from it's position to a position B
        transform.position = Vector3.Lerp(PosA, PosB, moveSpeed * Time.deltaTime);

        if(Math.Abs(PosA.x - PosB.x) < 0.1 )
        {
            checkColl = false;
            Debug.Log("Im free!");
            
            // Starts the dialogue
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();

            // We need to start an animation here that goes from the point where the player is to Breze and the next scene starts -- Artists Work 
            //player.AllowJump();
            //player.AllowMovement();
        }
    }

    public void FlyUp()
    {
        player.animator.SetBool("IsFlying", true);
        rigidbodyComponent.useGravity = false;

        Vector3 PosA = transform.position;
        Vector3 PosB = target.position;

        Invoke("loadSceneLevel2Gameplay" , 2.0f);
        transform.position = Vector3.Lerp(PosA, PosB, 0.5f * Time.deltaTime);
        if (Math.Abs(PosA.x - PosB.x) < 0.1)
        {
            checkConvoFinished = false;
            
        }
    }
    
    public void loadSceneLevel2Gameplay()
    {
        SceneManager.LoadScene("Level 2 Game");
    }

}
