using System;
using Assets.Scripts.General.Models;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public abstract class EntityBase : MonoBehaviour
    {
        public GameObject EntityPrefab { get; set; }
        public GameObject ParentLayer { get; set; }
        public Vector2 Position { get; set; }
    }
}
