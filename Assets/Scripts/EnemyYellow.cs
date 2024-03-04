using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYellow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform limitLeft, limitRight, limitTop, limitBottom, objective;
    
    void Start()
    {
        // Set the limits of the enemy's movement
        limitLeft.position = new Vector2(limitLeft.position.x,Random.Range(-5.5f, 5.5f)); // Set the limitLeft position
        limitRight.position = new Vector2(limitRight.position.x, Random.Range(-5.5f, 5.5f)); // Set the limitRight position
        limitTop.position = new Vector2(Random.Range(-3.5f, 3.5f), limitTop.position.y); // Set the limitTop position
        limitBottom.position = new Vector2(Random.Range(-3.5f, 3.5f), limitBottom.position.y); // Set the limitBottom position
        ResetPosition();
    }


    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, objective.position) < 0.2f)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Selects a random limit from the list to start form
        List<Transform> limits = new List<Transform> { limitLeft, limitRight, limitTop, limitBottom };
        int randomLimit = Random.Range(0, limits.Count);
        transform.position = limits[randomLimit].position;
        // Selects a random limit from the list to move towards, the limit has to be different from the one the enemy started from
        limits.RemoveAt(randomLimit);
        randomLimit = Random.Range(0, limits.Count);
        objective = limits[randomLimit];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
