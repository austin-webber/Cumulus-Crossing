using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT HANDLES THE AIRSHIP'S MOVEMENT ALONG THE X AXIS

public class AirshipMovement : MonoBehaviour
{
    // Declaring variables
    Rigidbody2D rb;
    public float thrust = 1.0f;

    private void Start()
    {
        // Creating a reference to the airship's rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate since we're doing physics calculations on a rigidbody
    void FixedUpdate()
    {
        // Adding a force to the airship's rigidbody along the x axis, multiplying it by a public float I can adjust in the inspector
        rb.AddForce(new Vector3(2.0f, 0.0f, 0.0f) * thrust * 10);
    }
}
