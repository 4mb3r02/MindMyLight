using System;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities.Behaviours
{
    public class BalloonBehaviour : MonoBehaviour, ICollectible
    {
        float moveAwaySpeed = 4;
        bool exitRange = true;
        public float rangeTimer;
    
        public void OnTriggerStay(Collider other)
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, -1 * moveAwaySpeed * Time.deltaTime);
            exitRange = false;
            rangeTimer = 2;
        
        }

        public void OnTriggerExit(Collider other)
        {        
            exitRange = true;        
        }

        public void MovingToPlayer()
        {
            rangeTimer -= Time.deltaTime;
            if (rangeTimer <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, 0.5f * moveAwaySpeed * Time.deltaTime);
            }
        }

        private void Update()
        {
            if (exitRange)
            {
                MovingToPlayer();
            }
        }
        public static event Action OnBalloonCollected;
        public void Collect()
        {
            Destroy(gameObject);
            OnBalloonCollected?.Invoke();
        }

    }
}
