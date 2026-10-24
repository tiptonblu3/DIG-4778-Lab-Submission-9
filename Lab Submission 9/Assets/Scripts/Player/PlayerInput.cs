using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    public PlayerStats playerStats;
    public PlayerMethods playerMethods;

    public List<GameObject> ProjectileList = new List<GameObject>();
    public int poolSize = 10;
    private int nextProjectileIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < poolSize; i++) // when the script starts, make a loop that:
        {
            GameObject obj = Instantiate(playerStats.arrowPrefab); // instantiate new projectile
            obj.SetActive(false); // disable projectile until called for
            ProjectileList.Add(obj); // add to a list
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetProjectile()
    {
        for(int i = 0; i < ProjectileList.Count; i++)
        {
            int index = (nextProjectileIndex + i) % ProjectileList.Count; // go through the list of projectiles, and choose the next item on the list to use
            if (!ProjectileList[index].activeInHierarchy) // if projectile not active
            {
                nextProjectileIndex = (index + 1) % ProjectileList.Count; // move to next item in list
                return ProjectileList[index];
            }

        }

        return null; // return null if nothing is available for use
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerStats.moveInput = context.ReadValue<Vector2>(); // Read the movement input from the Input System and store it in the moveInput variable
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        GameObject projectile = GetProjectile(); 

        if (projectile == null)
        {
            return;
        }
    
        if (context.performed && playerStats.canShoot)
        {
            projectile.transform.position = transform.position + new Vector3(0, 1, 0);
            projectile.transform.rotation = Quaternion.identity;
            projectile.SetActive(true);

            //gameObject obj = Instantiate(playerStats.arrowPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
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
