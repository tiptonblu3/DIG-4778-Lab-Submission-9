using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySaveData
{
    public string prefabName; // Name of the prefab in a Resources folder
    public Vector3 position;
    public Quaternion rotation;
    public int speed; // enemy speed data
}

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    
    public List<EnemySaveData> savedEnemies = new List<EnemySaveData>();
}