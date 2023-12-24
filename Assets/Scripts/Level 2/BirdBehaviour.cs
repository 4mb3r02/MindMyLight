using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdBehaviour : MonoBehaviour
{
    Rigidbody rigidbodyComponent;

    [field: SerializeField] 
    public MoveDirection Direction;


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
        if (Direction == MoveDirection.Right)
        {
            rigidbodyComponent.transform.Rotate(0, 180, 0);
        }
        rigidbodyComponent.velocity = -(transform.forward * speed);
    }

    public void SetDestroyLocation(float destroyLocationLeft, float destroyLocationRight)
    {
        destroyXLeft = destroyLocationLeft;
        destroyXRight = destroyLocationRight;
    }

    public void destroyBirdCheck(float locatieLeft, float locatieRight)
    {
        if(Direction == MoveDirection.Left && transform.position.x <= locatieLeft)
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
