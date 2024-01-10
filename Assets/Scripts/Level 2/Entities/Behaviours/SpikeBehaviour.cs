using UnityEngine;

namespace Assets.Scripts.Level_2.Entities.Behaviours
{
    public class SpikeBehaviour : MonoBehaviour
    {
        Rigidbody rigidbodyComponent;
        public GameObject spikeModel;

        [field: SerializeField]
        float rotationSpeed;

        [field: SerializeField]
        float movementSpeed;

        [field: SerializeField]
        float accelerationSpeed;

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
            Accelerate(accelerationSpeed);
            Spin(rotationSpeed);
            DestroySpikeCheck(destroyY);
        }

        public void Accelerate(float acceleration)
        {
            movementSpeed = movementSpeed * acceleration;
            MoveDown(movementSpeed);
        }

        public void MoveDown(float movementSpeed)
        {
            rigidbodyComponent.velocity = -transform.up * movementSpeed;
        }

        public void Spin(float rotationSpeed)
        {
            if (spikeModel != null)
                spikeModel.transform.Rotate(0, 0, +rotationSpeed);
        }

        public void SetDestroyLocation(float destroyLocation)
        {
            destroyY = destroyLocation;
        }

        public void DestroySpikeCheck(float destroyLocation)
        {
            if (destroyLocation >= transform.position.y)
            {
                Destroy(gameObject);
            }

        }
    }
}
