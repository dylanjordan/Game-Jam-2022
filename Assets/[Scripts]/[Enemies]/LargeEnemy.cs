using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LargeEnemy : MonoBehaviour
{
    GameObject player;
    private Rigidbody2D rb;

    public int currency = 5;

    [Header("Health")]
    int health;
    public int maxHealth = 2;
    bool showHealthbar = false;
    public Slider healthbar;

    public int damage;
    public bool canSeePlayer;

    [Header("Follow Player")]
    public float speed;

    [Header("Charge at Player")]
    public bool charge;
    float chargetimer;
    public float chargespeed;
    public float chargeTime;

    [Header("Sounds")]
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip spawnSound;

    [Header("Animation Stuff")]
    Animator animator;
    bool enemyAttacking;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
        player = GetComponent<PlayerMovement>().gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
