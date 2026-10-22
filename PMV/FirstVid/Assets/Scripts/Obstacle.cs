using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed;
    public float minY = -15f;
    public int damage = 1;
    
    void Start()
    {
        
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
