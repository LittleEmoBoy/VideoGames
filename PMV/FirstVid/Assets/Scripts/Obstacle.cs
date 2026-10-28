using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed;
    public float minY = -15f;
    public int damage = 1;
    public Generator generator;

    void Start()
    {
        generator = FindFirstObjectByType<Generator>();

        switch (generator.difficulty)
        {
            case Generator.Difficulty.Easy:
                fallSpeed = 1f;
                break;
            case Generator.Difficulty.Medium:
                fallSpeed = 2f;
                break;
            case Generator.Difficulty.Hard:
                fallSpeed = 15f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
