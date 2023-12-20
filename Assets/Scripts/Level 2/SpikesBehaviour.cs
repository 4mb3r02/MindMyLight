using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SpikesBehaviour : MonoBehaviour
{
    Rigidbody rigidbodyComponent;
    public GameObject spikeModel;

    [field: SerializeField]
    float rotationSpeed;

    [field: SerializeField]
    float movementSpeed;

    [field: SerializeField]
    float exelerationSpeed;

    [field: SerializeField]
    float destroyY;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = -transform.up;
        spikeModel = GameObject.Find("SpikeModel");
    }

    // Update is called once per frame
    void Update()
    {
        Exelerate(exelerationSpeed);
        Spin(rotationSpeed);
        DestroySpikeCheck(destroyY);
    }

    public void Exelerate(float exeleration)
    {
        movementSpeed = movementSpeed * exeleration;
        MoveDown(movementSpeed);
    }

    public void MoveDown(float movementSpeed)
    {
        rigidbodyComponent.velocity = -transform.up * movementSpeed;
    }

    public void Spin(float rotationSpeed)
    {
        spikeModel.transform.Rotate(0, 0, +rotationSpeed);
    }

    public void DestroySpikeCheck(float destroyLocation)
    {
        if (destroyLocation >= transform.position.y)
        {
            Destroy(gameObject);
        }
        
    }
}
