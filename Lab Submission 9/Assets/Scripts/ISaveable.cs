using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public interface ISaveable
{
    string SaveID { get; }
    // TransformSaveData SavedData { get; }
    // void LoadFromData(TransformSaveData data);

}

public class SavingService {
    public static void SaveGame(string fileName) 
    {
        
        Debug.Log("Game Saved");
    }

    public static void LoadGame(string fileName)
    {

        Debug.Log("Load Game");
    }   
}


