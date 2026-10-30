using UnityEngine;


public class SaveLoad : MonoBehaviour
{
    public string fileName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SavingService.SaveGame(fileName);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SavingService.LoadGame(fileName);
        }
    }
}
