using System;
using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Level_2
{
    public class LevelController : MonoBehaviour
    {

        //[Serializable]
        //public class Obstacle
        //{
        //    [SerializeField]
        //    public EntityBase Entity;
        //    public RectTransform SpawnArea;
        //    public MoveDirection MoveDirection;
        //}

        [Header("----------- Level Settings -----------")]
        public int AmountOfBalloons = 4;
        public int AmountOfSpikes = 10;
        public int AmountOfBirds = 20;

        //public Obstacle[] Obstacles;

        [Header("----------- Level Settings -----------")]
        public RectTransform[] BalloonSpawnAreas;

        [Header("------------ Level Models ------------")]
        public GameObject BalloonPrefab;
        public GameObject SpikePrefab;
        public GameObject BirdPrefab;

        [Header("------------- Background -------------")]
        public GameObject CloudPrefab;

        public GameObject CloudLayer;
        public int DistanceBetweenRadius = 50;

        private LevelBuilder _levelBuilder;

        private GameObject _levelLayer, _spawnAreaLeft, _spawnAreaTop, _spawnAreaRight, _spawnAreaBottom;

        // Start is called before the first frame update
        void Start()
        {
            _levelLayer = GameObject.Find("Level");
            _spawnAreaLeft = GameObject.Find("SpawnAreaLeft");
            _spawnAreaTop = GameObject.Find("SpawnAreaTop");
            _spawnAreaRight = GameObject.Find("SpawnAreaRight");
            _spawnAreaBottom = GameObject.Find("SpawnAreaBottom");

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

            AddBalloons();
            AddObstacles();
        }

        void AddBalloons()
        {
            _levelBuilder.SetSpawnAreas(BalloonSpawnAreas);

            var balloon = new Balloon()
            {
                EntityPrefab = BalloonPrefab,
                ParentLayer = _levelLayer
            };

            _levelBuilder.AddSpawnEntity(balloon, AmountOfBalloons);
            _levelBuilder.BuildArea(50);
        }

        void AddObstacles()
        {
            AddSpikes();

            var leftSpawnArea = _spawnAreaLeft.GetComponent<RectTransform>();
            AddBirds(leftSpawnArea, MoveDirection.Right);

            var rightSpawnArea = _spawnAreaRight.GetComponent<RectTransform>();
            AddBirds(rightSpawnArea, MoveDirection.Left);
        }

        void AddSpikes()
        {
            Spike spike = new Spike()
            {
                EntityPrefab = SpikePrefab,
                ParentLayer = _levelLayer
            };

            var spikeSpawnArea = _spawnAreaTop.GetComponent<RectTransform>();
            _levelBuilder.SetSpawnAreas(spikeSpawnArea);

            _levelBuilder.AddSpawnEntity(spike, AmountOfSpikes);
            _levelBuilder.BuildArea(10);

            spike.Activate();
        }

        void AddBirds(RectTransform spawnArea, MoveDirection moveDirection)
        {
            var amount = AmountOfBirds / 2;

            _levelBuilder.SetSpawnAreas(spawnArea);


            Bird bird = new Bird()
            {
                EntityPrefab = BirdPrefab,
                ParentLayer = _levelLayer,
                MoveDirection = moveDirection
            };
            _levelBuilder.AddSpawnEntity(bird, amount);
            _levelBuilder.BuildArea(10);

            bird.Activate();
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