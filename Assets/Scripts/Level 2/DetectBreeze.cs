using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBreeze : MonoBehaviour
{
    public Player player;
    public DialogueManager manager;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        manager.breezeCollected = true;
    }
}
