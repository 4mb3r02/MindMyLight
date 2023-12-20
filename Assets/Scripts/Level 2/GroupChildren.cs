using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupChildren : MonoBehaviour
{
    public Player player;
    
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        player.BlockJump();
        player.BlockMovement();
        player.animator.SetBool("IsWalking", false);
    }

}
