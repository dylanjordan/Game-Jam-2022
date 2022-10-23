using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallEnemy : MonoBehaviour
{
    GameObject player;
    private Rigidbody2D rb;

    [Header("Health")]
    int health;
    public int maxHealth = 2;
    bool showHealthbar = false;
    public Slider healthbar;

    public int damage;
    public bool canSeePlayer;

    [Header("Follow Player")]
    public bool follow;
    public float speed;

    [Header("Charge at Player")]
    public bool charge;
    float chargetimer;
    public float chargespeed;
    public float chargeTime;

    [Header("Shoot at Player")]
    public bool shoot;
    public GameObject bullet;
    public float bulletSpeed;
    public float reloadTime;
    float reloadtimer;
    


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
        player = GetComponent<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (showHealthbar)
        {
            UpdateHealthBar();
        }

        
        if (canSeePlayer)
        {
            if (follow)
            {
                Follow();
            }

            if (charge)
            {
                Charge();
            }

            if (shoot)
            {
                Shoot();
            }
        }
    }

    public void Hurt(int value)
    {
        if (!showHealthbar)
        {
            healthbar.gameObject.SetActive(true);
        }

    }

    void Follow()
    {
        Vector3 direction = player.transform.position - transform.position;

        rb.velocity = direction.normalized * speed * Time.deltaTime;
    }

    void Charge()
    {
        Vector3 direction = player.transform.position;

        chargetimer += Time.deltaTime;
        if (chargetimer >= chargeTime)
        {
            chargetimer = 0;
            rb.velocity = direction.normalized * chargespeed;
        }
    }

    void Shoot()
    {
        Vector3 direction = player.transform.position - transform.position;

        GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;

        Destroy(obj, 5f);
    }

    void Die()
    {

    }

    void UpdateHealthBar()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().HurtPlayer(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canSeePlayer = false;
        }
    }
}
