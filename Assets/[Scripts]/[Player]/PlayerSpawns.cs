using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawns : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    private bool canSpawn = true;
    private int spawners;
    [SerializeField] Vector2 lowerBounds;
    [SerializeField] Vector2 upperBounds;
    public int enemyCap = 10;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator Spawning()
        {
            yield return new WaitForSeconds(1);

            if (canSpawn)
            {
                for (int i = 0; i <= 0;)
                {
                    Vector2 pos = new Vector2(Random.Range(lowerBounds.x, upperBounds.x),
                        Random.Range(lowerBounds.y, upperBounds.y));
                    RaycastHit2D ray = Physics2D.CircleCast(pos, 1, Vector2.one);

                    if (!ray)
                    {
                        Debug.Log("hit nothing");

                        Instantiate(Prefab, pos, transform.rotation);
                        spawners++;
                        ++i;
                    }
                }
            }
        }
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCanSpawn();
    }

    void CheckIfCanSpawn()
    {
        if (spawners >= 1)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }

    public int GetEnemyCap()
    {
        return enemyCap;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
}
