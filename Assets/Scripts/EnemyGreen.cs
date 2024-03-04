using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
