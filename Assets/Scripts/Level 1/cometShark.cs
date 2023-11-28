using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    EnemieMovement Roam;
    // Start is called before the first frame update
    void Start()
    {
        Roam = gameObject.AddComponent(typeof(EnemieMovement)) as EnemieMovement;
        Roam.Awake();   
    }

    // Update is called once per frame
    void Update()
    {
        //if player is near
        //charge
        //if not -->
        Roam.setEnemieMovement();

    }
}
