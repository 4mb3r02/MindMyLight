using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.Level_2
{
    public interface IEntitySpawner
    {
        public void Spawn(Vector2Int gridIndex, GridSettings grid);
    }
}
