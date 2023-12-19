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

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = -transform.up;
        spikeModel = GameObject.Find("SpikeModel");

        movementSpeed = 1f;
        exelerationSpeed = 1.002f;
        rotationSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Exelerate(exelerationSpeed);
        Spin(rotationSpeed);
    }

    public void Exelerate(float exeleration)
    {
        movementSpeed = movementSpeed * exeleration;
        moveDown(movementSpeed);
    }

    public void moveDown(float movementSpeed)
    {
        rigidbodyComponent.velocity = -transform.up * movementSpeed;
    }

    public void Spin(float rotationSpeed)
    {
        spikeModel.transform.Rotate(0, 0, +rotationSpeed);
    }
}
