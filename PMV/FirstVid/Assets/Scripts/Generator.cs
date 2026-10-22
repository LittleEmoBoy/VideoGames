using UnityEngine;

public class Generator : MonoBehaviour
{


    [SerializeField] private GameObject[] objectsToGenerate;
    public float minIntervalObjects = 0.5f;
    public float maxIntervalObjects = 2f;
    public float timer = 0f;
    public float nextIntervalObjects;
    public float minX = -7.5f;
    public float maxX = 7.5f;
    public float minY = 3f;
    public float maxY = 4.37f;

    void Start()
    {
        nextIntervalObjects = Random.Range(minIntervalObjects, maxIntervalObjects);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextIntervalObjects)
        {
            //Genera un objeto en una posicion aleatoria
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);
            int randomIndex = Random.Range(0, objectsToGenerate.Length);
            Instantiate(objectsToGenerate[randomIndex], spawnPosition, Quaternion.identity);

            //Resetear el temporizador y calcular el primer intervalo de tiempo
            timer = 0f;
            nextIntervalObjects = Random.Range(minIntervalObjects, maxIntervalObjects);
        }
    }
}
