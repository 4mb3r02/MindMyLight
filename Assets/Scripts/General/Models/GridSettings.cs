using UnityEngine;

namespace Assets.Scripts.General.Models
{

    public class GridSettings
    {
        public const float InvertRootTwo = 0.70710678118f; // Becaust two dimension grid.

        public Vector2 BottomLeft { get; private set; }
        public Vector2 TopRight { get; private set; }
        public Vector2 Center { get; private set; }
        public Rect Dimension { get; private set; }
        public float MinimumDistance { get; private set; }
        public float CellSize { get; private set; }
        public int GridWidth { get; private set; }
        public int GridHeight { get; private set; }

        public static GridSettings Create(RectTransform rect, float minDistance)
        {
            Vector3[] worldCorners = new Vector3[4];
            rect.GetWorldCorners(worldCorners);
            var bl = worldCorners[0];
            var tr = worldCorners[2];

            var dimension = (tr - bl);
            var cell = minDistance * InvertRootTwo;

            return new GridSettings
            {
                BottomLeft = bl,
                TopRight = tr,
                Center = (bl + tr) * 0.5f,
                Dimension = new Rect(new Vector2(bl.x, bl.y), new Vector2(dimension.x, dimension.y)),

                MinimumDistance = minDistance,

                CellSize = cell,
                GridWidth = Mathf.CeilToInt(dimension.x / cell),
                GridHeight = Mathf.CeilToInt(dimension.y / cell)
            };
        }
    }
}
