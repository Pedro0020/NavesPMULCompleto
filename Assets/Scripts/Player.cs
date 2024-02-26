using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0f;
    [SerializeField] private float maxSpeed; // Max speed of the player is set in the inspector
    [SerializeField] private float rotationGrades; // Rotation speed of the player is set in the inspector

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float rotationMovement = Input.GetAxis("Horizontal");
        float movement = Input.GetAxis("Vertical");
        if (rotationMovement < 0)
        {
            transform.Rotate(0.0f, 0.0f, rotationGrades * Time.deltaTime, Space.Self);
        }
        else if (rotationMovement > 0)
        {
            transform.Rotate(0.0f, 0.0f, -rotationGrades * Time.deltaTime, Space.Self);
        }

        if (movement > 0 && speed < maxSpeed)
        { 
            speed += 0.05f;
        } 
        else if(movement < 0 && speed > 0)
        {
            speed -= 0.025f;
        }
        else if (movement == 0 && speed > 0)
        {
            speed -= 0.005f;
        }
        else if (movement < 0 && speed <= 0)
        {
            speed = 0f;
        }
        else if (movement > 0 && speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        // For debug
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
