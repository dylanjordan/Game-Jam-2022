using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class OverallEnemyPathfindingAI : MonoBehaviour
{
    public Transform bar;

    public float range = 10.0f;
    public bool isInRange;
    private AIDestinationSetter seeker;

    Vector2 playerPos;

    private void Start()
    {
        isInRange = false;
        seeker = GetComponent<AIDestinationSetter>();
    }
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
            seeker.target = bar;
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
