using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Level_2.Entities
{
    public class Bird : ObstacleSpawner, IEntitySpawner
    {
        public MoveDirection MoveDirection { get; set; }

        public void Spawn(Vector2Int gridIndex, GridSettings grid)
        {
            var entity = base.SpawnObstacle(gridIndex, grid);
            var levelTransform = entity.GetComponentInParent<RectTransform>();

            var birdBehaviour = entity.GetOrAddComponent<BirdBehaviour>();
            birdBehaviour.Direction = MoveDirection;
            birdBehaviour.SetDestroyLocation(levelTransform.rect.xMin, levelTransform.rect.xMax);

            var x = entity.CloneViaSerialization();

            var obstacle = entity.GetOrAddComponent<Obstacle>();
            obstacle.ParentLayer = ParentLayer;
            obstacle.SpawnSpeed = SpawnSpeed;
            obstacle.EntityPrefab = x;
            obstacle.Grid = grid;
            obstacle.Setup(gridIndex, grid);

        }
    }
}