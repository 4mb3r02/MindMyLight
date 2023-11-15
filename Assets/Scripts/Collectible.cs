using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private int coin = 0;
    private bool level1;

    void Start()
    {
        if ( level1 == true)
        {

        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        
    }
}
