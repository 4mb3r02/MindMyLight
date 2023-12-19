using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.Mathf;
//using UnityEngine.Mathf;
public class SpikesBehaviour : MonoBehaviour
{
    Rigidbody rigidbodyComponent;
    //EnemieMovement enemyMovement;
    //private Quaternion NewRotation;
    //float startPosition;
    // Start is called before the first frame update
    float startX;
    float startY;
    float endX;
    float endY;
    Quaternion rotate_from;
    Quaternion rotate_to;


    float distance;
    float nextX;
    float baseY;
    float height;

    float speed;
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = -transform.up;
        speed = 1f;




    }

    // Update is called once per frame
    void Update()
    {
        Exelerate(1.002f);

        //startX = -100;
        //startY = 0;

        //endX = 100;
        //endY = 10;
        


        //distance = startX - endX;

        //nextX = Mathf.MoveTowards(transform.position.x, endX, speed * Time.deltaTime);
        //baseY = Mathf.Lerp(startY, endY, (nextX - startX)/distance);
        //height = 2 * (nextX - startX) * (nextX - endX) / (-0.25f * distance * distance);

        //Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        //transform.rotation = LookAtTarget(movePosition - transform.position);
        //transform.position = movePosition;
        
        
        // enemyMovement.UpdateRotation(CurveRotation(), 1f);
        //transform = MathPerabola
        //enemyBody.velocity = transform.right * 10;
        
    }

    //public static Quaternion LookAtTarget(Vector2 rotation)
    //{
    //    return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    //}
    public void Exelerate(float exeleration)
    {
        speed = speed * exeleration;
        Debug.Log("speed: " + speed);
        moveDown(speed);
    }
    public void moveDown(float movementSpeed)
    {
        rigidbodyComponent.velocity = -transform.up * movementSpeed;
    }



    //public void     

    //public Quaternion CurveRotation()
    //{
    //    NewRotation.z = -0.1f*(startPosition * startPosition);
    //    Debug.Log("New rotation: " + NewRotation.z);
    //   // startPosition = startPosition * 0.5f;//* Time.deltaTime;
    //    return NewRotation;
    //}




}
