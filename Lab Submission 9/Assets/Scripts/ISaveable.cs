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

    public static void SaveGame(string fileName) 
    {
        
        Debug.Log("Game Saved");

        foreach (var saveable in registeredSaveables)
        {
            if (saveable is ScoreObserver scoreObserver)
            {
                scoreObserver.SaveScoreBinary(fileName);
            }
        }
    }

    public static void LoadGame(string fileName)
    {

        Debug.Log("Load Game");

        foreach (var saveable in registeredSaveables)
        {
            if (saveable is ScoreObserver scoreObserver)
            {
                scoreObserver.LoadScoreBinary(fileName);
            }
        }
    }   
}


