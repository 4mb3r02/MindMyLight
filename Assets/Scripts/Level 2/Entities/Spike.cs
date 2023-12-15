using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public class Spike : HazardSpawner, IEntitySpawner
    {
        [field: SerializeField]
        public GameObject SpikePrefab { get; set; }

        public void Spawn(Vector2Int gridIndex, GridSettings settings)
        {
            base.SpawnHazard(SpikePrefab, gridIndex, settings);
        }
    }
}