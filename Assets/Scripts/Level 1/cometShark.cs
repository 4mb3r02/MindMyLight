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

    public Vector3 topRightLimit;
    public Vector3 bottomLeftLimit;

    private Rigidbody rigidbodyComponent;

    EnemieMovement enemyMovement;
    GameObject player;
    Borders border;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rigidbodyComponent = GetComponent<Rigidbody>();
        enemyMovement = gameObject.AddComponent(typeof(EnemieMovement)) as EnemieMovement;
        border = gameObject.AddComponent(typeof(Borders)) as Borders;
        bottomLeftLimit = GameObject.Find("BottomLeftLimit").transform.position;
        topRightLimit = GameObject.Find("TopRightLimit").transform.position;
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
        enemyMovement.MoveForward(chargeSpeed);
        enemyMovement.UpdateRotation(enemyMovement.FindPlayerDirection(), turnSpeed);
    }
    
    private void SharkRoam()
    {
        enemyMovement.MoveForward(roamSpeed);
        enemyMovement.UpdateRotation(enemyMovement.GenerateRandomRotation(rotationRangeLeft, rotationRangeRight, cooldownTimeMin, cooldownTimeMax), turnSpeed);
    }
}
