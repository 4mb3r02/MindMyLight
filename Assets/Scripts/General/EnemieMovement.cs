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
    float rotationRangeLeft = -180f;
    float rotationRangeRight = 180f;
    float cooldownTimeMin = 3f;
    float cooldownTimeMax = 8f;
    float turnSpeed = 2;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    private float changeDirectionCooldown;
    Rigidbody enemyBody;
    Quaternion currentRotation;
    float angleChange;

    Quaternion _targetDirection;
    public void Awake()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
        enemyBody = GetComponent<Rigidbody>();
        currentRotation = new Quaternion(0, 0, gameObject.transform.rotation.z, 1); ;
    }

    private void FixedUpdate()
    {
        Move();
        GetRotationChange();
        UpdateRotation();
    }

    private void Move()
    {
        enemyBody.velocity = transform.up * movementSpeed;
    }

    private void GetRotationChange()
    {
        
        changeDirectionCooldown -= Time.deltaTime;
        if (changeDirectionCooldown <= 0)
        {
            angleChange = Random.Range(rotationRangeLeft, rotationRangeRight);
            _targetDirection.z = _targetDirection.z + angleChange;
            changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
            currentRotation.z = gameObject.transform.rotation.z;
        }
    }
    private void UpdateRotation()
    {
        Quaternion_Rotate_From = transform.rotation;
        Quaternion_Rotate_To = Quaternion.Euler(0, 0, _targetDirection.z);
        transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * turnSpeed);
    }


    public void setEnemieMovement()
    {
        Move();
        GetRotationChange();
        UpdateRotation();
    }
}
