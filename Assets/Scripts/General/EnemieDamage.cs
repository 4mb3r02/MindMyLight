using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDamage : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {    
       player = new Player();
    }

    private void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.tag == "Player")
        {
            player.TakeDamage();
        }
    }
}
