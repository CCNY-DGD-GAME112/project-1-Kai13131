using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        float xVal = Random.Range(-9, 9);
        float yVal = Random.Range(-9, 9);

        Instantiate(enemyPrefab, new Vector3(xVal, yVal, 0), Quaternion.identity);
    }
}
