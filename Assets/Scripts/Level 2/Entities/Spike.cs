using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities.Behaviours;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public class Spike : ObstacleSpawner, IEntitySpawner
    {
        public void Spawn(Vector2Int gridIndex, GridSettings grid)
        {
            var entity = base.SpawnObstacle(gridIndex, grid);
            var levelTransform = entity.GetComponentInParent<RectTransform>();

            var spikeBehaviour = entity.GetOrAddComponent<SpikeBehaviour>();
            spikeBehaviour.SetDestroyLocation(levelTransform.rect.yMin);
        }
    }
}