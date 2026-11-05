using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    [SerializeField] private float lowerLimit = -10f;



    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.z < lowerLimit)
        {
            Destroy(gameObject);
        }
    }
}
