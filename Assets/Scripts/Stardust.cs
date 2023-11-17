using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stardust : MonoBehaviour, ICollectible
{
    public static event Action OnStardustCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnStardustCollected?.Invoke();
    }

}
