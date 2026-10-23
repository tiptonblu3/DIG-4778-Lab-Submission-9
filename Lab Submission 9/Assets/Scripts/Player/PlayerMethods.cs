using UnityEngine;

public class PlayerMethods : MonoBehaviour
{
    public PlayerStats playerStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        playerStats.rb.linearVelocity = playerStats.moveInput.normalized * playerStats.speed; // Set the player's Rigidbody linear velocity to move the player in the desired direction at the specified speed

        // Clamp the player's position within the screen limits
        float clampedX = Mathf.Clamp(playerStats.rb.position.x, -playerStats.horizontalScreenLimit, playerStats.horizontalScreenLimit); // Clamp the player's position within the horizontal screen limits
        float clampedY = Mathf.Clamp(playerStats.rb.position.y, -playerStats.verticalScreenLimit, playerStats.verticalScreenLimit); // Clamp the player's position within the vertical screen limits
        playerStats.rb.position = new Vector2(clampedX, clampedY); // Update the player's position to the clamped values to ensure they stay within the screen limits

    }
}
