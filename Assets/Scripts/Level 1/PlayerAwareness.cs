using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    CharacterController controller;
    Transform target;
    GameObject Player;
    public bool AwareOfPlayer { get; private set;  }
    public Vector3 DirectionToPlayer { get; private set; }
    Vector3 enemyToPlayerVector = new Vector3();
    private Transform _player;

    [SerializeField]
    private float _playerAwarenessDistance;
    // Start is called before the first frame update
    void Start()
    {
        AwareOfPlayer = false;
        _player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        checkAwareOfPlayer();
    }
    public bool checkAwareOfPlayer()
    {
        enemyToPlayerVector = _player.position - transform.position;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
        return AwareOfPlayer;
    }
}
