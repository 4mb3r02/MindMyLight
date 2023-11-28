using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;
    public Transform enemy;
    public Transform collectible;
    public int count;
    public float rate;
}
