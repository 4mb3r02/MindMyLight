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


    [field: SerializeField]
    float destroyXLeft;

    [field: SerializeField]
    float destroyXRight;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        moveForward();
    }

    // Update is called once per frame
    void Update()
    {
        destroyBirdCheck(destroyXLeft, destroyXRight);
    }

    public void moveForward()
    {
        if (direction == movementDirection.Right)
        {
            rigidbodyComponent.transform.Rotate(0, 180, 0);
        }
        rigidbodyComponent.velocity = -(transform.forward * speed);
    }

    public void destroyBirdCheck(float locatieLeft, float locatieRight)
    {
        if(direction == movementDirection.Left && transform.position.x <= locatieLeft)
        {
            Destroy(gameObject);
        } else
        {
            if (transform.position.x >= locatieRight)
            {
                Destroy(gameObject);
            }
        }
    }
}
