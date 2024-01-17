using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Level_2
{
    public class ObstacleSpawner : EntityBase
    {
        private readonly List<GameObject> obstacles = new();

        public GameObject SpawnObstacle(Vector2Int gridIndex, GridSettings grid)
        {
            var xMin= Mathf.FloorToInt(grid.BottomLeft.x + (grid.CellSize * gridIndex.x));
            var yMin= Mathf.FloorToInt(grid.BottomLeft.y + (grid.CellSize * gridIndex.y));

            Position = new Vector3(
                Random.Range(xMin, xMin + grid.CellSize),
                Random.Range(yMin, yMin + grid.CellSize), 0
            );
            

            var entity = Instantiate(EntityPrefab, Position, EntityPrefab.transform.rotation, ParentLayer.transform);
            entity.SetActive(false);

            obstacles.Add(entity);

            return entity;
        }

        public void Activate()
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.SetActive(true);
            }
        }
    }
}