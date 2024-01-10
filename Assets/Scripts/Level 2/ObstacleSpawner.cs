using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Level_2
{ public class ObstacleSpawner : EntityBase
    {
        private readonly List<GameObject> obstacles = new();

        public GameObject SpawnObstacle(Vector2Int gridIndex, GridSettings grid)
        {
            Position = new Vector2(
                Random.Range(grid.BottomLeft.x, grid.TopRight.x),
                Random.Range(grid.BottomLeft.y, grid.TopRight.y)
            );

            var entity = Instantiate(EntityPrefab, Position, Quaternion.identity, ParentLayer.transform);
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