using System.Collections.Generic;
using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using UnityEngine;
using Settings = Assets.Scripts.General.PoissonDiskSampling;
namespace Assets.Scripts.Level_2
{
    internal class LevelBuilder
    {
        public static List<Vector2> GeneratePoints(RectTransform[] spawnAreas, int amount, float min)
        {
            var positions = new List<Vector2>();
            var usedIndexes = new KeyValuePair<GridSettings, List<Vector2Int>>[spawnAreas.Length];
            for (int i = 0; i < spawnAreas.Length; i++)
            {
                var settings = GridSettings.Create(spawnAreas[i], min);
                usedIndexes[i] = new KeyValuePair<GridSettings, List<Vector2Int>>(settings, new List<Vector2Int>());
            }

            for (int x = 0; x < amount; x++)
            {
                // Set index based on the rest value of the spawn areas length and current point
                int i = x % spawnAreas.Length;
                (GridSettings set, var value) = usedIndexes[i];

                Vector2Int gridIndex;
                Vector2 position;
                float halfCellSize = set.CellSize * .5f;
                // Recalculate if already in use
                do
                {
                    gridIndex = new Vector2Int(Random.Range(0, set.GridWidth), Random.Range(0, set.GridHeight));
                    position = new Vector2(
                        Mathf.FloorToInt(set.BottomLeft.x + (gridIndex.x * set.CellSize) + halfCellSize),
                        Mathf.FloorToInt(set.BottomLeft.y + (gridIndex.y * set.CellSize) + halfCellSize)
                    );
                } while (value.Contains(gridIndex));
                value.Add(gridIndex);
                positions.Add(position);
            }

            return positions;
        }
    }
}
