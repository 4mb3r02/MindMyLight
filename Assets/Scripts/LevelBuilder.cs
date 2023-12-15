using System.Collections.Generic;
using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts
{
    internal class LevelBuilder
    {
        private class SpawnEntitySettings
        {
            public int Amount;
            public IEntitySpawner Entity;
        }

        private List<SpawnEntitySettings> spawnEntities = new();
        private RectTransform[] spawnAreas;

        public void SetSpawnAreas(RectTransform[] areas)
        {
            this.spawnAreas = areas;
        }

        public void AddSpawnEntity(IEntitySpawner entity, int amount)
        {
            spawnEntities.Add(new SpawnEntitySettings()
            {
                Entity = entity,
                Amount = amount
            });
        }

        public void Reset()
        {
            spawnEntities = new List<SpawnEntitySettings>();
        }

        /// <summary>
        /// Builds the level
        /// </summary>
        /// <param name="minDistanceBetween"></param>
        public void Build(float minDistanceBetween)
        {
            var usedIndexes = new KeyValuePair<GridSettings, List<Vector2Int>>[spawnAreas.Length];
            for (int i = 0; i < spawnAreas.Length; i++)
            {
                var settings = GridSettings.Create(spawnAreas[i], minDistanceBetween);
                usedIndexes[i] = new KeyValuePair<GridSettings, List<Vector2Int>>(settings, new List<Vector2Int>());
            }

            foreach (var spawnEntity in spawnEntities)
            {
                for (int x = 0; x < spawnEntity.Amount; x++)
                {
                    // Set index based on the rest value of the spawn areas length and current point
                    int i = x % spawnAreas.Length;
                    (GridSettings settings, var value) = usedIndexes[i];

                    Vector2Int gridIndex;

                    // Recalculate if already in use
                    do
                    {
                        gridIndex = new Vector2Int(Random.Range(0, settings.GridWidth), Random.Range(0, settings.GridHeight));
                    } while (value.Contains(gridIndex));

                    value.Add(gridIndex);
                    spawnEntity.Entity.Spawn(gridIndex, settings);
                }
            }

            this.Reset();
        }
    }
}
