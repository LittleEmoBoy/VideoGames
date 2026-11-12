using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    [SerializeField] private float lowerLimit = -5f;
    private PlayerController playerController;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (transform.position.z < lowerLimit)
        {
            // Resta la vida si el jugador fue encontrado
            if (playerController != null)
            {
                playerController.DecreaseLife();
            }
            
            Destroy(gameObject);
        }
    }
}
