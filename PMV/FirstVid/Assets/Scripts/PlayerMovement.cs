using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int lifes;
    public float speed;
    public float minX = -7.5f;
    public float maxX = 7.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento horizontal
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        //Limitar el movimiento izquierda derecha
        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Debug.Log("Player hit an obstacle");
                Destroy(other.gameObject);
                lifes -= obstacle.damage;
                if (lifes <= 0)
                {
                    Debug.Log("Game Over");
                    Time.timeScale = 0f; // Detener el juego
                }
                else
                {
                    Debug.Log("Lifes: " + lifes);
                }
            }


        }
    }
}
