using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = ReadHorizontal();
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    float ReadHorizontal()
    {
        float direction = 0f; 
        
        Keyboard keyboard = Keyboard.current;
        
        if (keyboard == null) return 0f; 

        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            direction = 1f;
            spriteRenderer.flipX = false;
        }
        else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            direction = -1f;
            spriteRenderer.flipX = true;
        }

        if ((keyboard.spaceKey.wasPressedThisFrame || keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame) && TouchingGround())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        return direction;
    }

    private bool TouchingGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.down,0.2f);
        Collider2D colliderPlayer = GetComponent<Collider2D>();
        Vector2 rayOrigin = new Vector2(colliderPlayer.bounds.center.x, colliderPlayer.bounds.min.y - 0.5f);
        if (hit.collider != null && hit.collider != colliderPlayer)
        {
            return true;
        }
            return false;


    }
}