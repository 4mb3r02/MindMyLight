using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask playerMask;

    private Rigidbody rigidbodyComponent;
    private bool test = true;
    public Movement movement;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        if (test == true)
        {
            movement = gameObject.AddComponent(typeof(MovementNoGravity)) as MovementNoGravity;
        } else
        {
            movement = gameObject.AddComponent(typeof(MovementGravity)) as MovementGravity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.MovementController();
    }

    private void FixedUpdate()
    {
        movement.Jump(rigidbodyComponent, groundCheck, playerMask);
        movement.Moving(rigidbodyComponent);
    }
}
