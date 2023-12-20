using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupChildren : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

}
