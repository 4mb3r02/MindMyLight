using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikeSpin : MonoBehaviour
{
    Rigidbody star;
    private Quaternion rotate_from;
    private Quaternion rotate_to;

    // Start is called before the first frame update
    void Start()
    {
        star = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Spin(90f);
    }

    public void Spin(float rotate)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, (transform.rotation.z + rotate));
        UpdateRotation(rotation, 10f);

    }
    //Time.deltaTime * turnSpeed
    public void UpdateRotation(Quaternion rotate, float turnSpeed)
    {
        Debug.Log("rotation: " + transform.rotation.z);
        rotate_from = transform.rotation;
        rotate_to = Quaternion.Euler(0, 0, rotate.z);
        transform.rotation = Quaternion.Lerp(rotate_from, rotate_to, 0.005f);

    }
}
