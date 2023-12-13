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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.TakeDamage();
        }
    }
}
