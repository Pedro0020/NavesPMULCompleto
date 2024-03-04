using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
        LaunchLaser();
    }

    private void LaunchLaser()
    {
        Vector2 direction = player.position - transform.position; // Get the direction from the enemy to the player
        // We normalize the direction to get a vector with a magnitude of 1
        rb.velocity = direction.normalized * speed; // Set the velocity of the laser
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false); // Set the laser as inactive
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false); // Set the laser as inactive
    }
}
