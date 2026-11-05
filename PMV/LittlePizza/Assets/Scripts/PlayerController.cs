using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public float speed;
    [SerializeField] private float xMin, xMax;
    private float direction;

    public GameObject pizza;
    void Start()
    {
        
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
