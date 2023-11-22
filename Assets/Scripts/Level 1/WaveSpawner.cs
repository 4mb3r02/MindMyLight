using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING}

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
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
        Debug.Log("Spawning Wave " + _wave.name);
        state = SpawnState.SPAWNING;

        
        for(int i = 0; i < _wave.count; i++)
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
        Instantiate(_enemy, Vector3.zero, transform.rotation);
        Debug.Log("Spawning enemy: " + _enemy.name);
    }
}
