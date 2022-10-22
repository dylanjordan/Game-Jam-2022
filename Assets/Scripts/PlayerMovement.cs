using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private PlayerActions playerActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        playerActions = new PlayerActions();

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is NULL!");
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
}
