using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Level_2.Collisions
{
    public class HazardSpawner : MonoBehaviour
    {
        public void SpawnHazard(GameObject prefab, Vector2 position)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
