using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class OverallEnemyPathfindingAI : MonoBehaviour
{

    public float range = 10.0f;
    public bool isInRange;
    private AIDestinationSetter seeker;

    Transform playerPos;

    private void Start()
    {
        isInRange = false;
        seeker = GetComponent<AIDestinationSetter>();
    }
    private void Update()
    {
        playerPos = PlayerMovement.instance.transform;
    }

    private void FixedUpdate()
    {
        float range = 10.0f;
        if (Vector3.Distance(playerPos.position, transform.position) >= range)
        {
            Debug.LogWarning("Player is NOT in range");
            seeker.target = playerPos;
            isInRange = false;
        }
        else
        {
            Debug.LogWarning("Player is in range");
            isInRange = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public bool GetRangeBool()
    {
        return isInRange;
    }
}
