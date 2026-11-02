using UnityEngine;

public class PlayerSaver : MonoBehaviour, ISaveable
{
    [SerializeField] private string saveID = "Player";
    public string SaveID => saveID;
    public Rigidbody2D rb;

    private void OnEnable() => SavingService.Register(this);
    private void OnDisable() => SavingService.Unregister(this);

    public void PopulateSaveData(GameData data)
    {
        data.playerPosition = transform.position;
        data.playerRotation = transform.rotation;
    }

    public void LoadFromSaveData(GameData data)
    {
        rb.linearVelocity = Vector3.zero;

        transform.position = data.playerPosition;
        transform.rotation = data.playerRotation;
    }
    public TransformSaveData GetSaveData() => null;
    public void LoadFromData(TransformSaveData data) { }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}