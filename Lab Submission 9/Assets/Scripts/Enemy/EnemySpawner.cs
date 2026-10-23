using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public float spawnTime = 2f; // Changed to float for WaitForSeconds compatibility
    private Coroutine spawnCoroutine;

    void Start()
    {
        // Start the coroutine when the script initializes
        spawnCoroutine = StartCoroutine(SpawningRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator SpawningRoutine()
    {
        // Use a while loop so enemies spawn continuously over time
        while (true)
        {
            // Pause the coroutine
            yield return new WaitForSeconds(spawnTime);

            // Check if the list has items to prevent errors
            if (enemies != null && enemies.Count > 0)
            {
                int index = Random.Range(0, enemies.Count); // Selects a random prefab index
                GameObject enemyPrefab = enemies[index]; // Get random GameObject
                Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Spawn it
            }

            // Randomize the spawn time for the next iteration
            spawnTime = Random.Range(1f, 4f);
        }
    }
}