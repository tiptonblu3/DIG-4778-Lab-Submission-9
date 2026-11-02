using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISaveable
{
    string SaveID { get; }
    TransformSaveData GetSaveData();
    void LoadFromData(TransformSaveData data);
    void PopulateSaveData(GameData data);
    void LoadFromSaveData(GameData data);

}

public class SavingService {

    private static List<ISaveable> registeredSaveables = new List<ISaveable>();

    public static void Register(ISaveable saveable)
    {
        if (!registeredSaveables.Contains(saveable))
        {
            registeredSaveables.Add(saveable);
        }
    }

    // Called by components when they turn off or get destroyed
    public static void Unregister(ISaveable saveable)
    {
        registeredSaveables.Remove(saveable);
    }

    private static string GetFilePath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName + ".json");
    }

    public static void SaveGame(string fileName) 
    {
        GameData data = new GameData();
        
        Debug.Log("Game Saved");

        foreach (var saveable in registeredSaveables.ToList())
        {
            if (saveable is ScoreObserver scoreObserver)
            {
                scoreObserver.SaveScoreBinary(fileName);
            }

            saveable.PopulateSaveData(data);
        }
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetFilePath(fileName), json);
        
        Debug.Log("Game Saved to: " + GetFilePath(fileName));
    }

    public static void LoadGame(string fileName)
    {
        string path = GetFilePath(fileName);
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found at: " + path);
            //return;
        }

        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);

        Debug.Log("Load Game");

        foreach (var saveable in registeredSaveables.ToList())
        {
            if (saveable is ScoreObserver scoreObserver)
            {
                scoreObserver.LoadScoreBinary(fileName);
            }
            
            saveable.LoadFromSaveData(data);
        }
    }   
}


