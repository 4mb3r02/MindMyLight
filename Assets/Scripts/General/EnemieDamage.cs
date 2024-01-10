using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieDamage : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    public void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            player.TakeDamage();
        }
    }
}
