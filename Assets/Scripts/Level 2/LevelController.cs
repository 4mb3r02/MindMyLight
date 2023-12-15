using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using UnityEngine;

namespace Assets.Scripts.Level_2
{
    public class LevelController : MonoBehaviour
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

        private LevelBuilder _levelBuilder;

        // Start is called before the first frame update
        void Start()
        {
            CreateClouds();

            ConstructLevel();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ConstructLevel()
        {
            _levelBuilder = new LevelBuilder();
            _levelBuilder.SetSpawnAreas(SpawnAreas);

            AddBalloons();

            _levelBuilder.Build(50);
        }

        void AddBalloons()
        {
            var balloon = new Balloon()
            {
                BalloonPrefab = BalloonPrefab,
                LevelLayer = LevelLayer
            };

            _levelBuilder.AddSpawnEntity(balloon, AmountOfBalloons);
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