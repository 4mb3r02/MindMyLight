using UnityEngine;

namespace Assets.Scripts.Level_2.Collisions
{
    public class Bird : HazardSpawner
    {
        [field: SerializeField]
        public GameObject BirdPrefab { get; set; }

        public void Spawn()
        {
            var pos = Random.Range(0, 100);
            base.SpawnHazard(BirdPrefab, new Vector2(pos, pos));
        }
    }
}