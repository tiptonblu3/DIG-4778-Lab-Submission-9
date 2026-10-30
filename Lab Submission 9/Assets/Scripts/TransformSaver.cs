using UnityEngine;
using System;

public class TransformSaver : MonoBehaviour, ISaveable
{
    [SerializeField] private string saveID;
    
    public string SaveID
    {
        get { return saveID; }
    }
    
    void Awake()
    {
        saveID = Guid.NewGuid().ToString();
    }

    public TransformSaveData GetSaveData()
    {
        return new TransformSaveData // saves position and rotation of player / enemy
        {
            saveID = SaveID,
            position = transform.position,
            rotation = transform.rotation
        };
    }

    public void LoadFromData (TransformSaveData data)
    {
        transform.position = data.position;
        transform.rotation = data.rotation;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
