using Assets.Scripts.General;
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
            // var worldCorners = GetWorldCorners();
            //   var bl = worldCorners[0];
            //var tr = worldCorners[2];

            // var settings = PoissonDiskSampling.GetSettings(bl, tr, DistanceBetweenRadius);


            //var settings = PoissonDiskSampling.GetSettings(bl, tr, DistanceBetweenRadius, AmountOfBalloons);

            // var points = PoissonDiskSampling.Sampling(settings);
            var balloon = new Balloon()
            {
                BalloonPrefab = BalloonPrefab,
                LevelLayer = LevelLayer
            };
            // LevelLayer.GetComponent<RectTransform>();
            for (int i = 0; i < AmountOfBalloons; i++)
            {
                int area = Random.Range(0, SpawnAreas.Length);
                var spawnArea = SpawnAreas[area];
                float x = Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax);
                float y = Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax);
                Vector2 spawnPoint = new Vector2(x, y);
                var point = spawnArea.TransformPoint(spawnPoint);
                balloon.Spawn(point);
            }
        }

        void CreateClouds()
        {
            var worldCorners = GetWorldCorners();
            var bl = worldCorners[0];
            var tr = worldCorners[2];

            var settings = PoissonDiskSampling.GetSettings(bl, tr, DistanceBetweenRadius);
            settings.IterationPerPoint = PoissonDiskSampling.CalculateIterationPerPoint(settings);

            var points = PoissonDiskSampling.Sampling(settings);

            foreach (var point in points)
            {
                Instantiate(CloudPrefab, point, Quaternion.identity, CloudLayer.transform);
            }
        }

        Vector3[] GetWorldCorners()
        {
            var transform = GetComponent<RectTransform>();
            Vector3[] v = new Vector3[4];
            transform.GetWorldCorners(v);
            return v;
        }
    }
}