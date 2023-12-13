using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonMovement : MonoBehaviour, ICollectibleMovement
{
    float moveAwaySpeed = 3;
    
    public void OnTriggerStay(Collider other)
    {
        transform.position = Vector3.MoveTowards(transform.position, other.transform.position, -1 * moveAwaySpeed * Time.deltaTime);
    }

    
}
