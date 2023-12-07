using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Assets.Scripts.General;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [field: SerializeField]
    public GameObject CloudPrefab { get; set; }

    [field: SerializeField] 
    public GameObject BackgroundLayer { get; set; }

    [field: SerializeField] 
    public int DistanceBetweenRadius { get; set; } = 50;

    // Start is called before the first frame update
    void Start()
    {
        var rectSize = BackgroundLayer.GetComponent<RectTransform>().rect.size;

        var points = PoissonDiscSampling.GeneratePoints(DistanceBetweenRadius, rectSize);
        foreach (var point in points)
        {
            var position = BackgroundLayer.transform.TransformPoint(point);
            Instantiate(CloudPrefab, position, Quaternion.identity, BackgroundLayer.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
