using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NewBehaviourScript : MonoBehaviour
{
    double detectionRange = 5;
    
    int chargeSpeed = 5;
    int roamSpeed = 1;

    float turnSpeed = 2;

    float rotationRangeLeft = -180f;
    float rotationRangeRight = 180f;
    float cooldownTimeMin = 3f;
    float cooldownTimeMax = 8f;

    private Rigidbody rigidbodyComponent;

    EnemieMovement enemyMovement;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rigidbodyComponent = GetComponent<Rigidbody>();
        enemyMovement = gameObject.AddComponent(typeof(EnemieMovement)) as EnemieMovement;
        enemyMovement.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        GetSharkBehaviour();
        
    }
    private void GetSharkBehaviour()
    {
        Vector3 playerDirections = player.transform.position - transform.position;
        if (playerDirections.magnitude <= detectionRange) //<--
        {
            SharkCharge();
        }
        else
        {
            SharkRoam();
        }
    } 
    private void SharkCharge()
    {
        enemyMovement.MoveForward(chargeSpeed, rigidbodyComponent);
        enemyMovement.UpdateRotation(enemyMovement.FindPlayerDirection(), turnSpeed);
    }
    
    private void SharkRoam()
    {
        enemyMovement.MoveForward(roamSpeed, rigidbodyComponent);
        enemyMovement.UpdateRotation(enemyMovement.GenerateRandomRotation(rotationRangeLeft, rotationRangeRight, cooldownTimeMin, cooldownTimeMax), turnSpeed);
    }
}
