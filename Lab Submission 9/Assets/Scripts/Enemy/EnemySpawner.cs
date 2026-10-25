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
                GameObject selectedPrefab = enemies[Random.Range(0, enemies.Count)];
                int randomSpeed = Random.Range(2, 6);

                // Fluent assembly step-by-step
                GameObject newEnemy = new EnemyBuilder()
                .FromPrefab(selectedPrefab)
                .AtPosition(transform.position)
                .WithSpeed(randomSpeed)
                .Build();
            }

            // Randomize the spawn time for the next iteration
            spawnTime = Random.Range(1f, 4f);
        }
    }
}