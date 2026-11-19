using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 initialPosition, finalDestination;
    public Vector3 endPosition;
    private SpriteRenderer spriteRenderer;
    private bool movingToEnd;
    [SerializeField] private float velocity = 2f;


    void Awake()
    {
    }
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        initialPosition = transform.position;
        movingToEnd = true;
    }

    void Update()
    {
        MoveEnemy();
    }
    
    void FixedUpdate()
    {
        if (movingToEnd)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void MoveEnemy()
    {
        finalDestination = movingToEnd ? endPosition : initialPosition;
        transform.position = Vector3.MoveTowards(transform.position, finalDestination, velocity * Time.deltaTime);

        if (transform.position == endPosition) movingToEnd = false;
        else if (transform.position == initialPosition) movingToEnd = true;
    }
}
