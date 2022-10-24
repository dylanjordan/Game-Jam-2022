using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform _spawnParent;

    public List<SmallEnemy> _enemyTypes = new List<SmallEnemy>();

    public List<Transform> _spawnPoints = new List<Transform>();

    public int _desiredEnemies = 5;

    public float _spawnRate = 2.0f;

    private float _timeSinceLastSpawn = 0.0f;

    private bool _canSpawn = true;

    public static int _totalEnemies = 0;

    private void Start()
    {
        FindSpawns();
    }
    private void Update()
    {
        if (_spawnPoints.Count <= 0)
        {
            FindSpawns();
        }
        UpdateSpawnTimer();

        SpawnDesiredEnemies();
    }

    public void FindSpawns()
    {
        Spawner[] allObjects = FindObjectsOfType<Spawner>();
        
        foreach (Spawner i in allObjects)
        {
            _spawnPoints.Add(i.gameObject.transform);
        }
    }

    private void UpdateSpawnTimer()
    {
        
        if (!_canSpawn)
        {
            if (_timeSinceLastSpawn >= _spawnRate)
            {
                _canSpawn = true;
                _timeSinceLastSpawn = 0.0f;
            }

            _timeSinceLastSpawn += Time.deltaTime;

        }
    }

    private void SpawnDesiredEnemies()
    {
        if (_totalEnemies < _desiredEnemies)
        {
            if (_canSpawn)
            {
                SpawnRandomEnemy();

                _canSpawn = false;
            }
        }

        if (_desiredEnemies == 0)
        {
            Debug.LogWarning(gameObject.name + "  object desiredEnemies is set to 0.  Please set in Inspector.");
            _desiredEnemies = 5;
        }
    }

    private void SpawnRandomEnemy()
    {
        int enemyType = Random.Range(0, _enemyTypes.Count);

        int spawnPoint = Random.Range(0, _spawnPoints.Count);

        if (_enemyTypes.Count ==0)
        {
            Debug.LogError("No Enemies in Enemy Types List");
        }
        else
        {
            Instantiate(_enemyTypes[enemyType], _spawnPoints[spawnPoint].position, _spawnPoints[spawnPoint].rotation);
            Debug.Log("Spawned " + _enemyTypes[enemyType].name);
            _totalEnemies++;
        }
        
    }
}
