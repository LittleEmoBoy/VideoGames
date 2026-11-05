using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public int numberAnimals = 5;
    public GameObject [] animals = new GameObject[5];
    public float spawnInterval = 1.5f;
    public float startDelay = 2f;
    
    public void SpawnRandomAnimal()
    {
        float spawnxPos = Random.Range(-20f, 20f);
        Vector3 spawnPos = new Vector3(spawnxPos, 0, transform.position.z);

        int animalIndex = Random.Range(0, animals.Length);
        Instantiate(animals[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
