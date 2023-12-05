using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    GameObject player;
    int maxHealth = 3;
    int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = maxHealth;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        //add timer for damage cooldown

        lives = lives - 1;
        if (lives <= 0)
        {
            Destroy(player);//get game over screen;
        }
        //update player model according to the amound of lives
    }
}
