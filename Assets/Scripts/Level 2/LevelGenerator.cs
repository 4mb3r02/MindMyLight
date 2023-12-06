using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Assets.Scripts.General;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [field: SerializeField]
    public GameObject CloudPrefab { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        var rectSize =/* this.gameObject.*/GetComponent<RectTransform>().rect.size;
        var radius = 25;
        float cellSize = radius / Mathf.Sqrt(2);

        int[,] grid = new int[Mathf.CeilToInt(rectSize.x / cellSize), Mathf.CeilToInt(rectSize.y / cellSize)];
        int x = grid.GetLength(0);
        int y = grid.GetLength(1);

        var points = PoissonDiscSampling.GeneratePoints(radius, rectSize, x * y);
        foreach (var point in points)
        {
            var position = point;

            Instantiate(CloudPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
