using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 100f;

    private PlayerActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerActions();
    }

    private void OnEnable()
    {
        playerActions.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        playerActions.PlayerInput.Disable();
    }

    private void FixedUpdate()
    {
        playerActions.PlayerInput.Shoot.started += ctx => Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    void Shoot(Vector3 worldSpaceTarget)
    {
        Vector3 direction = worldSpaceTarget - transform.position;

        GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;

        Destroy(obj, 5f);
    }
}