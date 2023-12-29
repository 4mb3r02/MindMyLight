using System;
using Assets.Scripts.General.Models;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public abstract class EntityBase : ScriptableObject
    {
        public GameObject EntityPrefab { get; set; }
        public GameObject ParentLayer { get; set; }
        public Vector2 Position { get; set; }

        public void Init(GameObject entity, GameObject parent)
        {
            EntityPrefab = entity;
            ParentLayer = parent;
        }
    }
}
