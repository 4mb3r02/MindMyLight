using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DELETE THE COMENTS WHEN YOU HAVE IT CLEAR, THEY ARE JUST FOR NOT BURNING YOUR BRAIN ;)

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask playerMask;

    //I have changed it to public so we can choose in each level, we choose in unity
    public bool gravity;
    public Movement movement;
    // Added the animation script
    public new AutoAnimation animation;



    private Rigidbody rigidbodyComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        if (gravity == false)
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

    // For the animation
    private void OnTriggerEnter(Collider other)
    {
        if (animation != null)
        {
            animation.Collision(other);
        }
        else
        {
            Debug.Log("Im not finding the script, animation is null");
        }

    }
}
