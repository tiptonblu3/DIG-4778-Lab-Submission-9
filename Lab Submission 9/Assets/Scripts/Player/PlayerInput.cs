using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public PlayerStats playerStats;
    public PlayerMethods playerMethods;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerStats.moveInput = context.ReadValue<Vector2>(); // Read the movement input from the Input System and store it in the moveInput variable
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && playerStats.canShoot)
        {
            Instantiate(playerStats.arrowPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            playerStats.canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        playerStats.canShoot = true;
    }
}
