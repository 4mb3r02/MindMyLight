using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class HazardSpawner : MonoBehaviour
    {
        public void SpawnHazard(GameObject prefab, Vector2Int gridIndex, GridSettings settings)
        {
            Vector2 pos = new Vector2(
                 Random.Range(settings.BottomLeft.x, settings.TopRight.x),
                 Random.Range(settings.BottomLeft.y, settings.TopRight.y)
             );

            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
