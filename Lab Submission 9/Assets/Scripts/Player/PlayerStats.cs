using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject arrowPrefab;

    public float speed = 6f;
    public float horizontalScreenLimit = 10f;
    public float verticalScreenLimit = 6f;
    public bool canShoot = true;

    public Vector2 moveInput; // Variable to store the player's movement input
    public Rigidbody2D rb; // Reference to the player's Rigidbody component
}
