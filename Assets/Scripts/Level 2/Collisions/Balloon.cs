﻿using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

namespace Assets.Scripts.Level_2.Collisions
{
    public class Balloon : MonoBehaviour, ICollectible
    {
        [field: SerializeField]
        public GameObject BalloonPrefab { get; set; }

        [field: SerializeField]
        public GameObject LevelLayer { get; set; }

        public void Spawn(Vector2 pos)
        {
            Instantiate(BalloonPrefab, pos, Quaternion.identity, LevelLayer.transform);
        }

        public static event Action OnBalloonCollected;
        public void Collect()
        {
            Destroy(gameObject);
            OnBalloonCollected?.Invoke();
        }
    }
}