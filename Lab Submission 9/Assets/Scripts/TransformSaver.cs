using UnityEngine;
using System;

public class TransformSaver : MonoBehaviour, ISaveable
{
    public string SaveID { get; private set; }
    
    void Awake()
    {
        SaveID = Guid.NewGuid().ToString();
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
