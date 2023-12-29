using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.General
{
    // The algorithm is from the "Fast Poisson Disk Sampling in Arbitrary Dimensions" paper by Robert Bridson.
    // https://www.cs.ubc.ca/~rbridson/docs/bridson-siggraph07-poissondisk.pdf

    public static class PoissonDiskSampling
    {
        public const int DefaultIterationPerPoint = 30;

        public static List<Vector2> Sampling(RectTransform rect, float minimumDistance, int iterationPerPoint = DefaultIterationPerPoint)
        {
            var settings = GridSettings.Create(
                rect,
                minimumDistance
                );

            return Sampling(settings, iterationPerPoint);
        }

        public static List<Vector2> Sampling(GridSettings settings, int iterationPerPoint = DefaultIterationPerPoint)
        {
            var bags = new Bags()
            {
                Grid = new Vector2?[settings.GridWidth + 1, settings.GridHeight + 1],
                SamplePoints = new List<Vector2>(),
                ActivePoints = new List<Vector2>()
            };

            GetFirstPoint(settings, bags);

            var fixedIterationPerPoint = iterationPerPoint <= 0 ? DefaultIterationPerPoint : iterationPerPoint;
            do
            {
                var index = Random.Range(0, bags.ActivePoints.Count);

                var point = bags.ActivePoints[index];

                var found = false;
                for (var k = 0; k < fixedIterationPerPoint; k++)
                {
                    found = found | GetNextPoint(point, settings, bags);
                }

                if (found == false)
                {
                    bags.ActivePoints.RemoveAt(index);
                }
            }
            while (bags.ActivePoints.Count > 0);

            return bags.SamplePoints;
        }

        #region "Algorithm Calculations"
        private static bool GetNextPoint(Vector2 point, GridSettings set, Bags bags)
        {
            var found = false;
            var p = GetRandPosInCircle(set.MinimumDistance, 2f * set.MinimumDistance) + point;

            if (set.Dimension.Contains(p) == false)
            {
                return false;
            }

            var minimum = set.MinimumDistance * set.MinimumDistance;
            var index = GetGridIndex(p, set);
            var drop = false;

            // Although it is Mathf.CeilToInt(set.MinimumDistance / set.CellSize) in the formula, It will be 2 after all.
            var around = 2;
            var fieldMin = new Vector2Int(Mathf.Max(0, index.x - around), Mathf.Max(0, index.y - around));
            var fieldMax = new Vector2Int(Mathf.Min(set.GridWidth, index.x + around), Mathf.Min(set.GridHeight, index.y + around));

            for (var i = fieldMin.x; i <= fieldMax.x && drop == false; i++)
            {
                for (var j = fieldMin.y; j <= fieldMax.y && drop == false; j++)
                {
                    var q = bags.Grid[i, j];
                    if (q.HasValue == true && (q.Value - p).sqrMagnitude <= minimum)
                    {
                        drop = true;
                    }
                }
            }

            if (drop == false)
            {
                found = true;

                bags.SamplePoints.Add(p);
                bags.ActivePoints.Add(p);
                bags.Grid[index.x, index.y] = p;
            }

            return found;
        }

        private static void GetFirstPoint(GridSettings set, Bags bags)
        {
            var first = GetRandomPosition(set);

            var index = GetGridIndex(first, set);

            bags.Grid[index.x, index.y] = first;
            bags.SamplePoints.Add(first);
            bags.ActivePoints.Add(first);
        }
        #endregion

        #region "Utils"
        
        public static Vector2 GetRandomPosition(GridSettings set)
        {
            return new Vector2(
                Random.Range(set.BottomLeft.x, set.TopRight.x),
                Random.Range(set.BottomLeft.y, set.TopRight.y)
            );
        }

        public static Vector2Int GetGridIndex(Vector2 point, GridSettings set)
        {
            return new Vector2Int(
                Mathf.FloorToInt((point.x - set.BottomLeft.x) / set.CellSize),
                Mathf.FloorToInt((point.y - set.BottomLeft.y) / set.CellSize)
            );
        }

        public static int CalculateIterationPerPoint(GridSettings settings)
        {
            return Mathf.CeilToInt(settings.GridHeight * settings.GridWidth);
        }

        private static Vector2 GetRandPosInCircle(float fieldMin, float fieldMax)
        {
            var theta = Random.Range(0f, Mathf.PI * 2f);
            var radius = Mathf.Sqrt(Random.Range(fieldMin * fieldMin, fieldMax * fieldMax));

            return new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
        }
        #endregion
    }
}
