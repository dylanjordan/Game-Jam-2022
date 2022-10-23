using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool canSpawn;
    private float distance;
    Vector2 playerPos;
    Vector2 spawnerPosition;
    // Update is called once per frame

    private void Start()
    {
        canSpawn = true;
    }
    
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
        yield return new WaitForSeconds(5);
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
        }
        else
        {
            Debug.Log("Will not Spawn");
        }
    }
}
