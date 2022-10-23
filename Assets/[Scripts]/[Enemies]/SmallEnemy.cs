using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class SmallEnemy : MonoBehaviour
{
    AIDestinationSetter seeker;
    public AIPath aiStats;
    public OverallEnemyPathfindingAI ai;

    Transform playerPos;

    public int currency = 5;

    [Header("Health")]
    int health;
    public int maxHealth = 2;
    bool showHealthbar = false;
    public Slider healthbar;

    public int damage;
    public bool canSeePlayer;
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
    float logan;

    [Header("Sounds")]
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] AudioClip shootSound;

    [Header("Animation Stuff")]
    Animator animator;
    bool enemyAttacking;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<AIDestinationSetter>();
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
        animator = GetComponent<Animator>();
        logan = 2;
    }


    // Update is called once per frame
    void Update()
    {
        playerPos = PlayerMovement.instance.transform;

        if (showHealthbar)
        {
            UpdateHealthBar();
        }

        if (ai.GetRangeBool())
        {
            Follow();
        }
        else
        {
            aiStats.maxSpeed = 2;
        }

        Animations();




        //if (shoot)
        //{
        //    Shoot();
        //}

    }

    public void Hurt(int value)
    {
        health -= value;
        if (!showHealthbar)
        {
            healthbar.gameObject.SetActive(true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Follow()
    {
        seeker.target = playerPos;

        Charge();
    }

    void Animations()
    {
        Vector3 direction = seeker.target.position - transform.position;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    void Charge()
    {
        StartCoroutine(chargeTimer());
    }

    IEnumerator chargeTimer()
    {
        aiStats.maxSpeed = 0;
        yield return new WaitForSeconds(2);

        StartCoroutine(runningTime());
    }

    IEnumerator runningTime()
    {
        aiStats.maxSpeed = 10;
        yield return new WaitForSeconds(5);
        aiStats.maxSpeed = 0;
    }
    //void Shoot()
    //{
    //    reloadtimer += Time.deltaTime;
    //    if (reloadtimer >= reloadTime)
    //    {
    //        Vector3 direction = player.transform.position - transform.position;

    //        GameObject obj = Instantiate(bullet, transform.position, Quaternion.identity);
    //        obj.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;

    //        PlaySoundEffect(shootSound);
    //        Destroy(obj, 5f);
    //    }

    //}

    void Die()
    {
        PlaySoundEffect(deathSound);
        Destroy(this.gameObject);
    }

    void UpdateHealthBar()
    {
        healthbar.value = health;
    }

    void PlaySoundEffect(AudioClip sound)
    {
        if (sound)
        {
            AudioSource.PlayClipAtPoint(sound, this.transform.position);
        }
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
