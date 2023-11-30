using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NewBehaviourScript : MonoBehaviour
{
    EnemieMovement enemieMovement;
    private PlayerAwareness _playerAwareness;
    GameObject Player;
    double detectionRange;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        enemieMovement = gameObject.AddComponent(typeof(EnemieMovement)) as EnemieMovement;
        enemieMovement.Awake();
        _playerAwareness = GetComponent<PlayerAwareness>();
    }

    // Update is called once per frame
    void Update()
    {
        enemieMovement.moveForward();
       // GetRotationChange();
        enemieMovement.UpdateRotation(GetRotationChange());
        //i//f (_playerAwareness.AwareOfPlayer)
        //{
            //_targetDirection = _playerAwarenessController.DirectionToPlayer;

        //}
       
        //if player is near
        //charge
        //if not -->
        

    }
    private Quaternion GetRotationChange()
    {
        Vector3 playerDirections = Player.transform.position - transform.position;
        if (playerDirections.magnitude <= detectionRange) //<--
        {
            return enemieMovement.findPlayerDirection();

        }
        else
        {
            return enemieMovement.GenerateRandomRotation();
        }
    }
        
}
