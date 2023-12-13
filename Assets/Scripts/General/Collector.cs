using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        ICollectibleMovement collectibleMovement = other.GetComponent<ICollectibleMovement>();
        if (collectible != null)
        {
            collectible.Collect();
            if (collectibleMovement != null)
            {
                    collectibleMovement.OnTriggerStay(other);

            }
        }

        
    }
}
