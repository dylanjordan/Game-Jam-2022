using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private PlayerActions playerActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth;
    public Slider healthBar;
    bool canBeHit = true;
    public float invicibilityTime;
    float invicibilityTimer;

    public int currency;

    [Header("GameOver")]
    GameObject gameoverScreen;
    static public PlayerMovement instance;

    [Header("Sound Effects")]
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip deathSound;


    void Awake()
    {
        instance = this;
        playerActions = new PlayerActions();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is NULL!");
        }

        currentHealth = maxHealth;
        if (healthBar)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        else
        {
            Debug.LogWarning("No Slider for Healthbar");
        }

    }

    private void OnEnable()
    {
        playerActions.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        playerActions.PlayerInput.Disable();
    }

    void FixedUpdate()
    {
        moveInput = playerActions.PlayerInput.Movement.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
    }

    private void Update()
    {
        UpdateUI();
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (!canBeHit)
        {
            invicibilityTimer += Time.deltaTime;
            if (invicibilityTimer >= invicibilityTime)
            {
                canBeHit = true;
                invicibilityTimer = 0;
            }
        }
    }

    public void HurtPlayer(int val)
    {
        if (canBeHit)
        {
            PlaySoundEffect(hurtSound);
            currentHealth -= val;
            
        }
    }

    void UpdateUI()
    {
        healthBar.value = currentHealth;
    }

    void Die()
    {
        PlaySoundEffect(deathSound);
        if (gameoverScreen)
        {
            gameoverScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No Gameover Screen");
        }
        
    }

    void PlaySoundEffect(AudioClip sound)
    {
        if (sound)
        {
            AudioSource.PlayClipAtPoint(sound, this.transform.position);
        }
    }
   
}
