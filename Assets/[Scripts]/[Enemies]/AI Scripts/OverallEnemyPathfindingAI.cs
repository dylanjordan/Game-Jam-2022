using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class OverallEnemyPathfindingAI : MonoBehaviour
{
    public float range = 10.0f;

    private Seeker seeker;

    Vector2 playerPos;
    private void Update()
    {
        playerPos = PlayerMovement.instance.transform.position;
    }

    private void FixedUpdate()
    {
        float range = 15.0f;
        if (Vector3.Distance(playerPos, transform.position) >= range)
        {
            Debug.LogWarning("Player is NOT in range");
        }
        else
        {
            Debug.LogWarning("Player is in range");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
