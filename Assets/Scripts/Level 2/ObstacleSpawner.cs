using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Level_2
{
    //public class Obstalc : MonoBehaviour
    //{
    //    public static Example instance;
    //    void Start()
    //    {
    //        Example.instance = this;
    //    }
    //}

    //public class Obstacle : MonoBehaviour
    //{
    //    public bool StopSpawning = false;
    //    public float SpawnSpeed { get; set; }

    //    public void Start()
    //    {
    //        while(!StopSpawning) {

    //            yield return new WaitForSeconds(SpawnSpeed);
    //        }
    //    }
    //}

    public class ObstacleSpawner : EntityBase
    {
        public float SpawnSpeed { get; set; } = 10f;

        private List<GameObject> obstacles = new();

        public GameObject SpawnObstacle(Vector2Int gridIndex, GridSettings grid)
        {
            Position = new Vector2(
                Random.Range(grid.BottomLeft.x, grid.TopRight.x),
                Random.Range(grid.BottomLeft.y, grid.TopRight.y)
            );

            var entity = Instantiate(EntityPrefab, Position, Quaternion.identity, ParentLayer.transform);
            entity.SetActive(false);

            obstacles.Add(entity);

            return entity;
        }

        public void Activate()
        {
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.SetActive(true);
            }
        }
        //public void Activate()
        //{
        //    foreach (GameObject obstacle in obstacles)
        //    {
        //        obstacle.SetActive(true);
        //        Example.instance.StartCoroutine(Respawn(obstacle));
        //    }
        //}

        //private IEnumerator Respawn(GameObject obstacle)
        //{
        //    while (!StopSpawning)
        //    {
        //        //obstacle.transform.SetParent(null);
        //        Instantiate(EntityPrefab, obstacle.transform.position, Quaternion.identity, ParentLayer.transform);
        //        //have some delay between
        //        yield return new WaitForSeconds(SpawnSpeed);
        //    }
        //}

        //private IEnumerator Delay(float delayTime)
        //{
        //    yield return new WaitForSeconds(delayTime);
        //}
    }
}