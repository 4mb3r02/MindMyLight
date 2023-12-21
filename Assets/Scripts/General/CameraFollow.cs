using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoRotate : MonoBehaviour
{
    Vector3 offset;
    public DialogueManager dialogueManager;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position-transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.cameraOff)
        {
            Destroy(this);
        }
        else
        {
            transform.position = player.transform.position - offset;
        }
    }
}
