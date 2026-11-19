using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private float horizontalInput;
    private bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        if (jumpPressed)
        {
            if (TouchingGround())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            jumpPressed = false;
        }
    }

    void LateUpdate()
    {
        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void ReadInput()
    {
        horizontalInput = 0f;

        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            horizontalInput = 1f;
        }
        else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            horizontalInput = -1f;
        }

        if (keyboard.spaceKey.wasPressedThisFrame ||
            keyboard.wKey.wasPressedThisFrame ||
            keyboard.upArrowKey.wasPressedThisFrame)
        {
            jumpPressed = true;
        }
    }

    private bool TouchingGround()
    {
        Vector2 origin = new Vector2(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.02f);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        return hit.collider != null && hit.collider.CompareTag("Ground");
    }
}