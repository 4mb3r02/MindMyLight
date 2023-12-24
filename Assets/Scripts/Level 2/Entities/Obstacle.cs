using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.General.Models;
using UnityEngine;

namespace Assets.Scripts.Level_2.Entities
{
    public class Obstacle : EntityBase
    {
        private bool canRespawn = true;

        void Start()
        {
            if (canRespawn)
                StartCoroutine(Respawn());
        }

        public void SetRespawn(bool respawn)
        {
            canRespawn = respawn;
        }

        public void Setup(Vector2Int gridIndex, GridSettings grid)
        {
            Grid = grid;
            GridIndex = gridIndex;
        }

        public IEnumerator Respawn()
        {
            while (canRespawn)
            {
                yield return new WaitForSeconds(SpawnSpeed);
                SpawnObstacle(EntityPrefab);
            }
        }

        public GameObject SpawnObstacle(GameObject obstacle)
        {
            Position = new Vector2(
                Random.Range(Grid.BottomLeft.x, Grid.TopRight.x),
                Random.Range(Grid.BottomLeft.y, Grid.TopRight.y)
            );

            var entity = Instantiate(obstacle, Position, Quaternion.identity, ParentLayer.transform);
            return entity;
        }
        public GridSettings Grid { get; set; }
        public Vector2Int GridIndex { get; set; }
        public float SpawnSpeed { get; set; }

    }
}
