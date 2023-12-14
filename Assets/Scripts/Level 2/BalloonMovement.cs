using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonMovement : MonoBehaviour, ICollectibleMovement
{
    float moveAwaySpeed = 3;
    bool exitRange = true;
    public float rangeTimer;
    
    public void OnTriggerStay(Collider other)
    {
        transform.position = Vector3.MoveTowards(transform.position, other.transform.position, -1 * moveAwaySpeed * Time.deltaTime);
        exitRange = false;
        rangeTimer = 2;
        
    }

    public void OnTriggerExit(Collider other)
    {        
        exitRange = true;        
    }

    public void MovingToPlayer()
    {
        rangeTimer -= Time.deltaTime;
        if (rangeTimer <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, 0.5f * moveAwaySpeed * Time.deltaTime);
        }
    }

    private void Update()
    {

        if (exitRange)
        {
            MovingToPlayer();
        }
    }


}
