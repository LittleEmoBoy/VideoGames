using UnityEngine;

public class NewPrefabs : MonoBehaviour
{

    [SerializeField] private int numSpheres;
    [SerializeField] private GameObject spherePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float []scale = new float[numSpheres];
        for (int i = 0; i < numSpheres; i++)
        {
            scale [i] = Random.Range(0.5f, 2f);
        }

        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Instantiate(spherePrefab, randomPosition, Quaternion.identity);
            
            Instantiate(spherePrefab, randomPosition, Quaternion.identity).transform.localScale = new Vector3(scale[i], scale[i], scale[i]);
        }
    
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
