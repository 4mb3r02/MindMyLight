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
    float rotationRangeLeft = 90f;
    float rotationRangeRight = 90f;
    float cooldownTimeMin = 3f;
    float cooldownTimeMax = 8f;
    float turnSpeed = 1;



    private float changeDirectionCooldown;
    Rigidbody enemyBody;

    Vector3 _targetDirection;
    public void Awake()
    {
        changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
        enemyBody = GetComponent<Rigidbody>();
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
            float angleChange = Random.Range(rotationRangeLeft, rotationRangeRight);
            if (_targetDirection.z + angleChange > 360) {
                _targetDirection.z = transform.eulerAngles.z + angleChange - 360;
            } else
            {
                _targetDirection.z = transform.eulerAngles.z + angleChange;
            }
            
            changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
        }
        _targetDirection.z = 365;
        
    }
    private void UpdateRotation()
    {
        Vector3 currentRotation = new Vector3(0, 0, 1);
        Debug.Log("old X: " + transform.rotation.eulerAngles.x + " Y: " + transform.rotation.eulerAngles.y + " Z: " + transform.rotation.eulerAngles.z);
        //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, _targetDirection, turnSpeed * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(currentRotation, _targetDirection, turnSpeed * Time.deltaTime);
        Debug.Log("Go to X: " + _targetDirection.x + " Y: " + _targetDirection.y + " Z: " + _targetDirection.z);
        //Debug.Log("old X: " + transform.rotation.eulerAngles.x + " Y: " + transform.rotation.eulerAngles.y + " Z: " + transform.rotation.eulerAngles.z); 
    }
    

    public void setEnemieMovement()
    {
        Move();
        GetRotationChange();
        UpdateRotation();
    }
}
