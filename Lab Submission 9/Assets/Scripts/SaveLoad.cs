using UnityEngine;
using UnityEngine.InputSystem;


public class SaveLoad : MonoBehaviour
{
    public string fileName;

    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset inputActionAsset;

    private InputAction saveAction;
    private InputAction loadAction;

    private void Awake()
    {
        if (inputActionAsset != null)
        {
            // Find the "Save" and "Load" actions you created in your asset
            saveAction = inputActionAsset.FindAction("Save");
            loadAction = inputActionAsset.FindAction("Load");
        }
        else
        {
            Debug.LogError("Input Action Asset is not assigned on the SaveLoad script!");
        }
    }

    private void OnEnable()
    {
        if (saveAction != null)
        {
            saveAction.Enable();
            saveAction.performed += OnSaveTriggered;
        }

        if (loadAction != null)
        {
            loadAction.Enable();
            loadAction.performed += OnLoadTriggered;
        }
    }

    private void OnDisable()
    {
        if (saveAction != null)
        {
            saveAction.performed -= OnSaveTriggered;
            saveAction.Disable();
        }

        if (loadAction != null)
        {
            loadAction.performed -= OnLoadTriggered;
            loadAction.Disable();
        }
    }

    private void OnSaveTriggered(InputAction.CallbackContext context)
    {
        SavingService.SaveGame(fileName);
    }

    private void OnLoadTriggered(InputAction.CallbackContext context)
    {
        SavingService.LoadGame(fileName);
    }
}
