using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.General.Models
{
    public class Bags
    {
        public Vector2?[,] Grid { get; set; }
        public List<Vector2> SamplePoints { get; set; }
        public List<Vector2> ActivePoints { get; set; }
    }
}
