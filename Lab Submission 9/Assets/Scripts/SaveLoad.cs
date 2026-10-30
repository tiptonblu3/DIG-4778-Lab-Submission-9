using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public SavingService savingSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            savingSystem.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            savingSystem.LoadGame();
        }
    }
}
