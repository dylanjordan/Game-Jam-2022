using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemySpawns enemy;
    private bool canSpawn = true;
    private float distance;
    private float spawnRate;

    private int enemyCap;
    private int enemyNum;
    Vector2 playerPos;
    Vector2 spawnerPosition;
    // Update is called once per frame

    private void Update()
    {
        enemyCap = enemy.GetEnemyCap();
        enemyNum = enemy.GetEnemyCount();
    }
    void FixedUpdate()
    {
        if (checkCanSpawn())
        {
            playerPos = PlayerMovement.instance.transform.position;
            spawnerPosition = transform.position;

            if (canSpawn)
            {
                StartCoroutine(CalculateDist());
            }
        }

    }

    IEnumerator CalculateDist()
    {
        distance = Vector3.Distance(playerPos, spawnerPosition);
        SpawnCheck();
        canSpawn = false;
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }

    void SpawnCheck()
    {
        var range = 30;
        if (distance > range)
        {
            Spawn();

        }
        else
        {
            return;
        }
    }

    void Spawn()
    {
        var spawn = Random.Range(1, 2);
        if (spawn == 1)
        {
            Debug.Log("Will Spawn");
            canSpawn = false;
        }
        else
        {
            Debug.Log("Will not Spawn");
        }
    }

    private bool checkCanSpawn()
    {
        if (enemyCap > enemyNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
