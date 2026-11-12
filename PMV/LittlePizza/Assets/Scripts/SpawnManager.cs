using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public int numberAnimals = 5;
    public GameObject [] animals = new GameObject[5];
    public float spawnInterval = 1.5f;
    public float startDelay = 0.5f;
    public GameManager gameManager;

    
    public void SpawnRandomAnimal()
    {
        float spawnxPos = Random.Range(-20f, 20f);
        Vector3 spawnPos = new Vector3(spawnxPos, 0, transform.position.z);

        int animalIndex = Random.Range(0, animals.Length);
        Instantiate(animals[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
    }



    void Start()
    {
        switch (gameManager.currentDifficulty)
        {
            case GameManager.difficulty.Easy:
                spawnInterval = 2f;
                break;
            case GameManager.difficulty.Medium:
                spawnInterval = 1.5f;
                break;
            case GameManager.difficulty.Hard:
                spawnInterval = 0.5f;
                break;
        }
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
