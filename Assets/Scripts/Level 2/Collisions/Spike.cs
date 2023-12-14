using UnityEngine;

namespace Assets.Scripts.Level_2.Collisions
{
    public class Spike : HazardSpawner
    {
        [field: SerializeField]
        public GameObject SpikePrefab { get; set; }

        public void Spawn()
        {
            var pos = Random.Range(0, 100);
            base.SpawnHazard(SpikePrefab, new Vector2(pos, pos));
        }
    }
}