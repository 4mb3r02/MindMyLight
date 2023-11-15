using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stardust : Collectible
{
    private int coin = 0;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "coin")
        {
            coin++;
            Debug.Log(coin);
            Destroy(other.gameObject);
        }
    }
}
