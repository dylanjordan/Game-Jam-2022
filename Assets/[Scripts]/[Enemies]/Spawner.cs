using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool canSpawn = true;
    private float distance;
    private float spawnRate;
    Vector2 playerPos;
    Vector2 spawnerPosition;
    // Update is called once per frame

    void FixedUpdate()
    {
        playerPos = PlayerMovement.instance.transform.position;
        spawnerPosition = transform.position;
        
        if (canSpawn)
        {
            StartCoroutine(CalculateDist());
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

  
}
