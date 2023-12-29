using System;
using Assets.Scripts.General.Models;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

namespace Assets.Scripts.Level_2.Entities
{
    public class Balloon : EntityBase, ICollectible, IEntitySpawner
    {
        public void Spawn(Vector2Int gridIndex, GridSettings settings)
        {
            // Uses center position within the calculated grid element index
            float halfCellSize = settings.CellSize * .5f;
            Vector2 pos = new Vector2(
                Mathf.FloorToInt(settings.BottomLeft.x + (gridIndex.x * settings.CellSize) + halfCellSize),
                Mathf.FloorToInt(settings.BottomLeft.y + (gridIndex.y * settings.CellSize) + halfCellSize)
            );

            var entity = Instantiate(EntityPrefab, pos, Quaternion.identity, ParentLayer.transform);
            entity.AddComponent<BalloonRange>();
        }

        public static event Action OnBalloonCollected;
        public void Collect()
        {
            Destroy(EntityPrefab);
            OnBalloonCollected?.Invoke();

        }
    }
}
