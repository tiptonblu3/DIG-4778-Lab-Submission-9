using UnityEngine;

public class EnemyID : MonoBehaviour
{
    [Tooltip("Name of the Prefab (..., Enemy 1, Enemy 2,...)")]
    public string prefabResourcePath;
    public int speed;

    private void Start()
    {
        // Automatically register with the spawner manager when spawned or loaded
        EnemySpawnerManager manager = FindAnyObjectByType<EnemySpawnerManager>();
        if (manager != null)
        {
            manager.RegisterActiveEnemy(gameObject);
        }
    }
}
