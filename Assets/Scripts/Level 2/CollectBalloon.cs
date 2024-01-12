using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBalloon : MonoBehaviour
{
    // Start is called before the first frame update
   // public static event Action OnStardustCollected;
    public void Collect()
    {
        Destroy(gameObject);
        Debug.Log("Hi there!");
        //OnStardustCollected?.Invoke();
    }
}
