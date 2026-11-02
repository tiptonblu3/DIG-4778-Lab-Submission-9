using UnityEngine;

public class EnemySaver : MonoBehaviour, ISaveable
{
    [SerializeField] private string saveID;
    [Tooltip("Exact name of the prefab inside a Resources folder")]
    [SerializeField] private string prefabResourcePath; 
    public EnemyStats EnemyStats;

    public string SaveID => saveID;

    private void OnEnable() => SavingService.Register(this);
    private void OnDisable() => SavingService.Unregister(this);

    public void PopulateSaveData(GameData data)
    {
        EnemySaveData enemyData = new EnemySaveData
        {
            prefabName = prefabResourcePath,
            position = transform.position,
            rotation = transform.rotation,
            speed = EnemyStats.speed
        };

        data.savedEnemies.Add(enemyData);
    }

    void Start()
    {
        // Automatically register with the spawner manager when spawned or loaded
        EnemySpawnerManager manager = FindAnyObjectByType<EnemySpawnerManager>();
        if (manager != null)
        {
            manager.RegisterActiveEnemy(gameObject);
        }

        EnemyStats = GetComponent<EnemyStats>();
    }

    public void LoadFromSaveData(GameData data){}
    public TransformSaveData GetSaveData() => null;
    public void LoadFromData(TransformSaveData data) {}
}