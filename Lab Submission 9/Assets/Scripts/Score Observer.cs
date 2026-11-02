using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreObserver : MonoBehaviour, ISaveable
{

    [SerializeField] private string saveID = "PlayerScore";
    public string SaveID => saveID;

    public TextMeshProUGUI Scoretext;
    private int FinalScore;
    void Start()
    {
        Scoretext = GetComponent<TextMeshProUGUI>();
    }



    private void OnEnable()
    {
        SavingService.Register(this);
        Arrow.OnScoreUpdated += scorechange;
    }

    private void OnDisable()
    {
        SavingService.Unregister(this);
        Arrow.OnScoreUpdated -= scorechange;
    }

    private void scorechange(int score)
    {
        FinalScore += score;
        UIRefresh();
    }

    private void UIRefresh()
    {
        if (Scoretext != null)
        {
            Scoretext.SetText("{0}", FinalScore);
        }
    }

    public void SaveScoreBinary(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + "_score.bin");
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write(FinalScore);
        }
    }

    public void LoadScoreBinary(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + "_score.bin");
        if (File.Exists(path))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                FinalScore = reader.ReadInt32(); // Read saved score from binary file
            }

            // evoke event to notify UI of the score being loaded
            UIRefresh();
            Debug.Log($"Score loaded: {FinalScore}");
        }
        else
        {
            Debug.LogWarning("Score binary file not found");
        }
    }

    // for everything in ISaveable that isn't used
    public TransformSaveData GetSaveData() => null;
    public void LoadFromData(TransformSaveData data) { }
    public void PopulateSaveData(GameData data){}
    public void LoadFromSaveData(GameData data){}

}



   