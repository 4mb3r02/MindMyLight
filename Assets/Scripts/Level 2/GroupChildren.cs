using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupChildren : MonoBehaviour
{
    public Player player;
    public DialogueManager manager;
    
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        player.BlockJump();
        player.BlockMovement();
        player.animator.SetBool("IsWalking", false);
        manager.convoChildrenOver = true;
    }

}
