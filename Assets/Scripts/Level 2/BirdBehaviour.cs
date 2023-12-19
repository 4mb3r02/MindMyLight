using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdBehaviour : MonoBehaviour
{
    Rigidbody rigidbodyComponent;
    enum movementDirection
    {Left, Right}

    [field: SerializeField]
    movementDirection direction;

    [field: SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        moveForward();

        
        
    }

    // Update is called once per frame
    void Update()
    {
       // rigidbodyComponent.velocity = transform.right;
    }

    public void moveForward()
    {
        if (direction == movementDirection.Left)
        {
            rigidbodyComponent.transform.Rotate(0, 180, 0);
        }
        rigidbodyComponent.velocity = transform.right * speed;
    }
}
