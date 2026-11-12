using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public float speed;
    [SerializeField] private float xMin, xMax;
    private float direction;

    public GameObject pizza;
    private int lifes;
    public GameManager gameManager;


    void Start()
    {
        if (gameManager != null)
        {
            switch (gameManager.currentDifficulty)
            {
                case GameManager.difficulty.Easy:
                    lifes = 5;
                    break;
                case GameManager.difficulty.Medium:
                    lifes = 3;
                    break;
                case GameManager.difficulty.Hard:
                    lifes = 1;
                    break;
            }
        }
        else
        {
            Debug.LogWarning("GameManager not assigned in PlayerController.");
            lifes = 3; // Default value if GameManager is not assigned
        }
    }

    public void DecreaseLife()
    {
        lifes--;
        Debug.Log("Lives remaining: " + lifes);
        if (lifes <= 0)
        {
            // Handle game over logic here
            Debug.Log("Game Over!");
            Time.timeScale = 0f; // Pauses the game
        }
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            {
                direction = -1f;
            }
            if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            {
                direction = 1f;
            }
        }
        transform.Translate(direction * speed * Time.deltaTime,0f,0f);
        direction = 0f; // Resetting the direction after each frame

        //Limiting the player movement to the screen bounds
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, xMin, xMax);
        transform.position = position;

        if (keyboard != null && keyboard.spaceKey.wasPressedThisFrame)
        {
            Instantiate(pizza, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }

    }
}
