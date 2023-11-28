using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    private enum SpawnState { SPAWNING, WAITING, COUNTING}

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
    public Transform[] enemySpawnPoints;

    private ArrayList enemy;

    private float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError(" There are no Spawnpoints");
        }
        waveCountdown = timeBetweenWaves;
        
    }

    void Update()
    {
        if ( state == SpawnState.WAITING)
        {
            if (!StarpieceIsCollected())
            {
                //Begin a new round
                WaveIsCompleted();
                return;
            }
            else
            {
                return;
            }

        }
        //Needs to be changed to work on collecting a star piece and not a timer
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning a wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        enemy =  new ArrayList();
        Debug.Log("Spawning Wave " + _wave.name);
        state = SpawnState.SPAWNING;

        spawnStardust(_wave.collectible);

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break; 
    }

    void WaveIsCompleted()
    {
        Debug.Log("Wave completed");

        
        foreach (Transform _enemy in enemy)
        {
            Destroy(_enemy.gameObject);
        }


        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            // needs to be end of level
            nextWave = 0;
            Debug.Log("All waves completed looping");
        }
        else
        {
           nextWave++;
        }

        
    }

    bool StarpieceIsCollected()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Stardust") == null)
            {
                
                return false;
            }
        }
        return true;
    }

    //Change the transform to the enemy object
    void SpawnEnemy(Transform _enemy)
    {
        //Spawning logic
        Debug.Log("Spawning enemy: " + _enemy.name);
        
        Transform _esp = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

        enemy.Add( Instantiate(_enemy, _esp.position, _esp.rotation));

        //Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }

    void spawnStardust(Transform _collectible)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(_collectible, _sp.position, _sp.rotation);
    }
}
