using UnityEngine;

namespace Assets.Scripts.General.Models
{

    public class GridSettings
    {
        public const float InvertRootTwo = 0.70710678118f; // Becaust two dimension grid.

        public Vector2 BottomLeft;
        public Vector2 TopRight;
        public Vector2 Center;
        public Rect Dimension;

        public float MinimumDistance;

        public float CellSize;
        public int GridWidth;
        public int GridHeight;

        public static GridSettings Create(RectTransform rect, float min)
        {
            Vector3[] worldCorners = new Vector3[4];
            rect.GetWorldCorners(worldCorners);
            var bl = worldCorners[0];
            var tr = worldCorners[2];

            var dimension = (tr - bl);
            var cell = min * InvertRootTwo;

            return new GridSettings
            {
                BottomLeft = bl,
                TopRight = tr,
                Center = (bl + tr) * 0.5f,
                Dimension = new Rect(new Vector2(bl.x, bl.y), new Vector2(dimension.x, dimension.y)),

                MinimumDistance = min,

                CellSize = cell,
                GridWidth = Mathf.CeilToInt(dimension.x / cell),
                GridHeight = Mathf.CeilToInt(dimension.y / cell)
            };
        }
    }
}
