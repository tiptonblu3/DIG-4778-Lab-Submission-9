using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour, ISaveable
{
    [SerializeField] private string saveID = "EnemySpawnerManager";
    public string SaveID => saveID;

    // List tracking active enemies currently alive in the scene
    private List<GameObject> activeEnemies = new List<GameObject>();

    private void OnEnable() => SavingService.Register(this);
    private void OnDisable() => SavingService.Unregister(this);

    public void PopulateSaveData(GameData data)
    {
        // Clear old list in data and remove any destroyed references from our tracking list
        data.savedEnemies.Clear();
        activeEnemies.RemoveAll(enemy => enemy == null);

        foreach (var enemyObj in activeEnemies)
        {
            if (enemyObj == null) continue;

            EnemyID identifier = enemyObj.GetComponent<EnemyID>();
            if (identifier != null)
            {
                EnemySaveData enemyData = new EnemySaveData
                {
                    prefabName = identifier.prefabResourcePath,
                    position = enemyObj.transform.position,
                    rotation = enemyObj.transform.rotation,
                    speed = identifier.speed
                };

                data.savedEnemies.Add(enemyData);
            }
        }
    }

    public void LoadFromSaveData(GameData data)
    {
        // Clear all existing active enemies from the scene
        foreach (var enemyObj in activeEnemies)
        {
            if (enemyObj != null)
            {
                Destroy(enemyObj);
            }
        }
        activeEnemies.Clear();

        // Respawn enemies from the saved JSON data
        foreach (var enemyData in data.savedEnemies)
        {
            // Load prefab from the Resources folder
            GameObject prefab = Resources.Load<GameObject>(enemyData.prefabName);
            if (prefab != null)
            {
                GameObject newEnemy = Instantiate(prefab, enemyData.position, enemyData.rotation);

                // Restore custom data
                EnemyID identifier = newEnemy.GetComponent<EnemyID>();
                if (identifier != null)
                {
                    identifier.prefabResourcePath = enemyData.prefabName;
                    identifier.speed = enemyData.speed;
                }
                EnemyStats stats = newEnemy.GetComponent<EnemyStats>();
                if (stats != null)
                {
                    stats.speed = enemyData.speed;
                }

                activeEnemies.Add(newEnemy);
            }
            else
            {
                Debug.LogWarning("Could not load enemy prefab from Resources path: " + enemyData.prefabName);
            }
        }
    }

    // Public method called by EnemyIdentifier on Start
    public void RegisterActiveEnemy(GameObject enemy)
    {
        if (!activeEnemies.Contains(enemy))
        {
            activeEnemies.Add(enemy);
        }
    }
    public TransformSaveData GetSaveData() => null;
    public void LoadFromData(TransformSaveData data) { }
}