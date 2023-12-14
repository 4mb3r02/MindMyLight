using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectibleMovement
{ 
    public void OnTriggerStay(Collider other)
    {
    }

    public void OnCollisionExit(Collision other) { }
}
