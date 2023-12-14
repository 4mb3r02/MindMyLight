using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Collisions;
using UnityEngine;

namespace Assets.Scripts.Level_2
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("----------- Level Settings -----------")]
        public int AmountOfBalloons = 4;

        public GameObject BalloonPrefab;
        public GameObject LevelLayer;
        public RectTransform[] SpawnAreas;

        [Header("----------- Background -----------")]
        public GameObject CloudPrefab;

        public GameObject CloudLayer;
        public int DistanceBetweenRadius = 50;

        // Start is called before the first frame update
        void Start()
        {
            CreateClouds();
            //todo
            ConstructLevel();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ConstructLevel()
        {
            CreateBalloons();
        }

        void CreateBalloons()
        {
            var balloon = new Balloon()
            {
                BalloonPrefab = BalloonPrefab,
                LevelLayer = LevelLayer
            };

            var points = LevelBuilder.GeneratePoints(SpawnAreas, AmountOfBalloons, 50);
            foreach (var point in points)
            {
                balloon.Spawn(point);
            }
        }

        void CreateClouds()
        {
            var rect = GetComponent<RectTransform>();
            var settings = GridSettings.Create(rect, DistanceBetweenRadius);
            var iterationPerPoint = PoissonDiskSampling.CalculateIterationPerPoint(settings);

            var points = PoissonDiskSampling.Sampling(settings, iterationPerPoint);

            foreach (var point in points)
            {
                Instantiate(CloudPrefab, point, Quaternion.identity, CloudLayer.transform);
            }
        }
    }
}