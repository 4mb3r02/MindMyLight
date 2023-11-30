//using System;
//using System;
//using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class EnemieMovement : MonoBehaviour
{
    
    int movementSpeed = 1;
    int roamSpeed = 1;
    int chargeSpeed = 5;
    float rotationRangeLeft = -180f;
    float rotationRangeRight = 180f;
    float cooldownTimeMin = 3f;
    float cooldownTimeMax = 8f;
    float turnSpeed = 2;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    private float changeDirectionCooldown;
    public PlayerAwareness playerAwareness;
    Rigidbody enemyBody;
    Quaternion currentRotation;
    float angleChange;
    GameObject Player;
    Transform target;
    Vector3 playerDirections;
    double detectionRange;

    Quaternion _targetDirection;
    public void Awake()
    {
       
        changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
        enemyBody = GetComponent<Rigidbody>();
        currentRotation = new Quaternion(0, 0, gameObject.transform.rotation.z, 1); ;
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        Vector3 playerDirections = new Vector3(0, 0, 0);
        detectionRange = 5.0;
    }

    private void FixedUpdate()
    {
         //Move();
         //GetRotationChange();
        // UpdateRotation();
    }

    private void damagePlayer()
    {
        //make player take damage
    }

    public Quaternion findPlayerDirection()
    {
        Vector3 direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _targetDirection.z = angle - 90;
        movementSpeed = chargeSpeed;
        return _targetDirection;
    }
    public void moveForward()
    {
        enemyBody.velocity = transform.up * movementSpeed;

    }

 //   private void GetRotationChange()
  //  {
        //Collider[] hitColliders = Physics.OverlapSphere(Player.transform.position, 5.0);
  //      playerDirections = target.position - transform.position;
  //      if (playerDirections.magnitude <= detectionRange) //<--
 //       {
 //           findPlayerDirection();

 //       } else
 //       {
 //           GenerateRandomRotation();
//        }
        
 //   }

    public Quaternion GenerateRandomRotation()
    {
        movementSpeed = roamSpeed;
        changeDirectionCooldown -= Time.deltaTime;
        if (changeDirectionCooldown <= 0)
        {
            angleChange = Random.Range(rotationRangeLeft, rotationRangeRight);
            _targetDirection.z = _targetDirection.z + angleChange;

            changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
            currentRotation.z = gameObject.transform.rotation.z;
        }
        return currentRotation;
    }
    public void UpdateRotation(Quaternion rotate)
    {
        Quaternion_Rotate_From = transform.rotation;
        Quaternion_Rotate_To = Quaternion.Euler(0, 0, rotate.z);
        transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * turnSpeed);
    }
}
