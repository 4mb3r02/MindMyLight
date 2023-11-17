using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    private float rotationSpeed;
    private Rigidbody cometShark;
    float x;
    Vector3 wanderSpeed = new Vector3(-2, 0, 0);
    //float wanderRotation = 5.0;
    // Start is called before the first frame update
    void Awake()
    {
        cometShark = GetComponent<Rigidbody>();
        //transform.position += new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;

        SetEnemieMovement();
        RotateInDirectionOfInput();


        //  transform.rotation = Quaternion.Euler(0, 0, x);
        //  wanderSpeed += new Vector3();
        //Quaternion targetRotation = Quaternion.LookRotation(wanderSpeed);
        //       targetRotation = Quaternion.RotateTowards(
        //               transform.rotation,
        //               targetRotation,
        //                360 * Time.fixedDeltaTime);
        //cometShark.MoveRotation(targetRotation);
        //cometShark.rotation = targetRotation;

        //transform.rotation = Quaternion.LookRotation(wanderSpeed);
        //transform.rotation = Quaternion.LookRotation(wanderSpeed);
    }

    private void SetEnemieMovement()
    {
        x += Time.deltaTime * 20;
        transform.position += wanderSpeed * Time.deltaTime;

    }

    private void RotateInDirectionOfInput()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, transform.position);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        cometShark.MoveRotation(rotation);
    }

}
