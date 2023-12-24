using System;
using System.Collections.Generic;
using Assets.Scripts.General.Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Level_2
{
    internal class LevelBuilder
    {
        private class SpawnEntitySettings
        {
            public int Amount;
            public IEntitySpawner Entity;
        }

        private class SpawnAreaSettings
        {
            public RectTransform[] SpawnAreas;
            public List<SpawnEntitySettings> SpawnEntities = new();
        }

        //private readonly Dictionary<Guid, SpawnAreaSettings> spawnAreas = new();

        //public Guid AddSpawnArea(RectTransform[] area)
        //{
        //    var spawnArea = new SpawnAreaSettings()
        //    {
        //        SpawnAreas = area
        //    };
        //    var key = Guid.NewGuid();

        //    spawnAreas.Add(key, spawnArea);

        //    return key;
        //}

        //public void AddSpawnEntity(Guid areaId, IEntitySpawner entity, int amount)
        //{
        //    if (!spawnAreas.ContainsKey(areaId))
        //        throw new KeyNotFoundException("Spawn entity could not be added, because spawn area could not be found");

        //    spawnAreas[areaId].SpawnEntities.Add(new SpawnEntitySettings()
        //    {
        //        Entity = entity,
        //        Amount = amount,
        //    });
        //}

        private List<SpawnEntitySettings> spawnEntities = new();
        private RectTransform[] spawnAreas;

        public void SetSpawnAreas(params RectTransform[] areas)
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
           // spawnAreas.Clear();
           spawnAreas = null;
           spawnEntities = new List<SpawnEntitySettings>();
        }

        /// <summary>
        /// Builds the level
        /// </summary>
        /// <param name="minDistanceBetween"></param>
        public void BuildArea(float minDistanceBetween)
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
