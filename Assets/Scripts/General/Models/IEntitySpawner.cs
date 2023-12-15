using UnityEngine;

namespace Assets.Scripts.General.Models
{
    public interface IEntitySpawner
    {
        public void Spawn(Vector2Int gridIndex, GridSettings settings);
    }
}
