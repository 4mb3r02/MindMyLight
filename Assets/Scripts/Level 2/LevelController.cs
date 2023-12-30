using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using Assets.Scripts.General;
using Assets.Scripts.General.Models;
using Assets.Scripts.Level_2.Entities;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

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

        #region Editor Settings
        [Header("----------- Level Settings -----------")]
        public int AmountOfBalloons = 4;
        public RectTransform[] BalloonSpawnAreas;

        [Header("----------- Obstacle Settings -----------")]
        public int SpikeMinDistanceBetween = 20;
        public int BirdMinDistanceBetween = 20;
        public float SpikeSpawnTime = 5f;
        public float BirdSpawnTime = 5f;

        [Header("------------ Level Models ------------")]
        public GameObject SpikePrefab;
        public GameObject BirdPrefab;

        [Header("------------- Background -------------")]
        public GameObject CloudPrefab;

        public GameObject CloudLayer;
        public int CloudMinDistanceBetween = 50;
        #endregion

        #region Variables
        private LevelCreator levelCreator;

        private GameObject _levelLayer, _spawnAreaLeft, _spawnAreaTop, _spawnAreaRight, _spawnAreaBottom;
        private bool isPlaying = true;

        private AssetBundle balloonPrefabsBundle;
        private int collectedBalloons;
        private GameObject[] balloonPrefabs;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            levelCreator = new LevelCreator();

            balloonPrefabsBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "prefabs/balloons"));
            balloonPrefabs = balloonPrefabsBundle.LoadAllAssets<GameObject>();

            _levelLayer = GameObject.Find("Level");
            _spawnAreaLeft = GameObject.Find("SpawnAreaLeft");
            _spawnAreaTop = GameObject.Find("SpawnAreaTop");
            _spawnAreaRight = GameObject.Find("SpawnAreaRight");
            _spawnAreaBottom = GameObject.Find("SpawnAreaBottom");

            AddClouds();
            ConstructLevel();

            Balloon.OnBalloonCollected += OnBalloonCollected;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            balloonPrefabsBundle.Unload(true);
        }

        void ConstructLevel()
        {
            AddBalloons();
            AddObstacles();
        }

        void AddBalloons()
        {
            levelCreator.SetSpawnAreas(BalloonSpawnAreas);

            for (int i = 0; i < AmountOfBalloons; i++)
            {
                var balloon = ScriptableObject.CreateInstance<Balloon>();
                var entity = balloonPrefabs[Random.Range(0, balloonPrefabs.Length)];
                balloon.Init(entity, _levelLayer);

                levelCreator.AddSpawnEntity(balloon, 1);
            }

            levelCreator.BuildArea(50);
        }

        private void OnBalloonCollected()
        {
            collectedBalloons++;
            // Collected all balloons
            if (collectedBalloons == AmountOfBalloons)
            {
                isPlaying = false;
            }
        }

        void AddObstacles()
        {
            StartCoroutine(AddSpikes());

            var leftSpawnArea = _spawnAreaLeft.GetComponent<RectTransform>();
            StartCoroutine(AddBirds(leftSpawnArea, MoveDirection.Right));

            var rightSpawnArea = _spawnAreaRight.GetComponent<RectTransform>();
            StartCoroutine(AddBirds(rightSpawnArea, MoveDirection.Left));

        }

        IEnumerator AddSpikes()
        {
            while (isPlaying)
            {
                Spike spike = ScriptableObject.CreateInstance<Spike>();
                spike.Init(SpikePrefab, _levelLayer);

                RectTransform spikeSpawnArea = _spawnAreaTop.GetComponent<RectTransform>();
                GridSettings grid = GridSettings.Create(spikeSpawnArea, SpikeMinDistanceBetween);

                levelCreator.SetSpawnArea(spikeSpawnArea);
                levelCreator.AddSpawnEntity(spike, grid.GridWidth / 3);
                levelCreator.BuildArea(grid);

                spike.Activate();

                yield return new WaitForSeconds(SpikeSpawnTime);
            }
        }

        IEnumerator AddBirds(RectTransform spawnArea, MoveDirection moveDirection)
        {
            while (isPlaying)
            {
                Bird bird = ScriptableObject.CreateInstance<Bird>();
                bird.Init(BirdPrefab, _levelLayer);
                bird.MoveDirection = moveDirection;

                GridSettings grid = GridSettings.Create(spawnArea, BirdMinDistanceBetween);

                levelCreator.SetSpawnArea(spawnArea);
                levelCreator.AddSpawnEntity(bird, grid.GridHeight / 3);
                levelCreator.BuildArea(grid);

                bird.Activate();

                yield return new WaitForSeconds(BirdSpawnTime);
            }
        }

        void AddClouds()
        {
            var rect = GetComponent<RectTransform>();
            var settings = GridSettings.Create(rect, CloudMinDistanceBetween);

            var points = PoissonDiskSampling.Sampling(settings, true);

            foreach (var point in points)
            {
                Instantiate(CloudPrefab, point, Quaternion.identity, CloudLayer.transform);
            }
        }
    }
}