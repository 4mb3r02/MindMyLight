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
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    private float changeDirectionCooldown;
    Rigidbody enemyBody;
    float angleChange;
    GameObject player;

    Quaternion targetDirection;
    public void Awake()
    {
        changeDirectionCooldown = 5.0f;
        enemyBody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    public Quaternion FindPlayerDirection()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        targetDirection.z = angle - 90;
        return targetDirection;
    }

    public void MoveForward(int movementSpeed)
    {
        enemyBody.velocity = transform.up * movementSpeed;
    }

    public Quaternion GenerateRandomRotation(float rotationRangeLeft, float rotationRangeRight, float cooldownTimeMin, float cooldownTimeMax)
    {
        changeDirectionCooldown -= Time.deltaTime;
        if (changeDirectionCooldown <= 0)
        {
            angleChange = Random.Range(rotationRangeLeft, rotationRangeRight);
            targetDirection.z = targetDirection.z + angleChange;
            changeDirectionCooldown = Random.Range(cooldownTimeMin, cooldownTimeMax);
        }
        return targetDirection;
    }

    public void UpdateRotation(Quaternion rotate, float turnSpeed)
    {
        Quaternion_Rotate_From = transform.rotation;
        Quaternion_Rotate_To = Quaternion.Euler(0, 0, rotate.z);
        transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * turnSpeed);
    }
}
