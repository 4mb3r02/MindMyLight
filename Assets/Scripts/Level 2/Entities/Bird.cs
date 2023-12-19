using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public class Bird : HazardSpawner, IEntitySpawner
    {
        [field: SerializeField]
        public GameObject BirdPrefab { get; set; }

        public void Spawn(Vector2Int gridIndex, GridSettings settings)
        {
            base.SpawnHazard(BirdPrefab, gridIndex, settings);
        }
    }
}