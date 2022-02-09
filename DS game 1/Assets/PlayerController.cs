using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Quaternion rotation;    // Rotation value
    private int score = 0;          // Current score tracker

    // Start is called before the first frame update
    void Start()
    {
        // set rotation to current value
        rotation = transform.rotation;
    }

    void LateUpdate()
    {

        // Go foward 
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 2.5f * Time.deltaTime;
        }
        // Go back
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 2.5f * Time.deltaTime;
        }
        // Go left 
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 2.5f * Time.deltaTime;
        }
        // Go right 
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 2.5f * Time.deltaTime;
        }
        // Turn right 
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
        // Turn left 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }
        // Rotation for turning 
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        // When Player collides with coin
        if (other.tag.Equals("coin"))
        {
            // Destroy dot and add 1 to score 
            Destroy(other.gameObject);
            score += 1;
        }
        // When Player collides with coin
        else if (other.tag.Equals("Star"))
        {
            // finish game 
            score = 100;
        }
        // Control collisions with wall 
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position -= transform.forward * 0.25f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position += transform.forward * 0.25f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += transform.right * 0.25f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position -= transform.right * 0.25f;
            }
        }
    }

    // Return score value 
    public int getScore()
    {
        return score;
    }

}
