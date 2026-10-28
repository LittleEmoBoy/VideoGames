using UnityEngine;

public class Generator : MonoBehaviour
{


    [SerializeField] public GameObject[] objectsToGenerate;
    private float minIntervalObjects = 0.5f;
    private float maxIntervalObjects = 2f;
    public float timer = 0f;
    public float nextIntervalObjects;
    public float minX = -7.5f;
    public float maxX = 7.5f;
    public float minY = 3f;
    public float maxY = 4.37f;
    public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
    public Difficulty difficulty = Difficulty.Medium;

    void Start()
    {
        nextIntervalObjects = Random.Range(minIntervalObjects, maxIntervalObjects);
        switch (difficulty)
        {
            case Difficulty.Easy:
                minIntervalObjects = 1f;
                maxIntervalObjects = 2f;
                break;
            case Difficulty.Medium:
                minIntervalObjects = 0.5f;
                maxIntervalObjects = 1.5f;
                break;
            case Difficulty.Hard:
                minIntervalObjects = 0.2f;
                maxIntervalObjects = 1f;
                break;
        }
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
