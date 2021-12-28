using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT HANDLES THE PLAYER CONTROLLER

public class PlayerController : MonoBehaviour
{
    // Declaring variables
    public float moveSpeed = 1.0f;

    public GameObject bottomWind;
    public Transform bottomWindSpawnPoint;
    public GameObject topWind;
    public Transform topWindSpawnPoint;
    public float windSpeed = 1.0f;

    public GameObject playerBottom;
    public GameObject playerTop;

    // Creating a method that instantiates a wind object shooting up from the bottom cloud
    private void SpawnWindBottom()
    {
        // The wind game object is assigned in the inspector
        GameObject newWind = Instantiate(bottomWind) as GameObject;
        // Instantiate the object at the correct position assigned in the inspector
        newWind.transform.position = bottomWindSpawnPoint.position;
        // Access the instantiated wind's rigidbody component
        Rigidbody2D newWindRB = newWind.gameObject.GetComponent<Rigidbody2D>();
        // Assign a new velocity to the rigidbody component in the upwards direction
        newWindRB.velocity = new Vector2(0f, 1f) * windSpeed * 10;
    }

    // Creating a method that instantiates a wind object shooting down from the top cloud
    private void SpawnWindTop()
    {
        // Identical functionality to SpawnWindBottom()
        GameObject newWind = Instantiate(topWind) as GameObject;
        newWind.transform.position = topWindSpawnPoint.position;
        Rigidbody2D newWindRB = newWind.gameObject.GetComponent<Rigidbody2D>();
        // Here's the difference: Assigning a new velocity in the downwards direction
        newWindRB.velocity = new Vector2(0f, -1f) * windSpeed * 10;
    }

    private void Awake()
    {
        // Creating references to the top and bottom clouds that the player moves
        playerBottom = GameObject.Find("PlayerBottom");
        playerTop = GameObject.Find("PlayerTop");
    }


    void Update()
    {
        // Letting the player move left and right based on the keys assigned to "Horizontal" in Unity's Input Manager
        float horizontalInput = Input.GetAxis("Horizontal");
        // Accessing the transform component and assigning a new x-axis component from -1 to 1 based on the player's input
        transform.Translate(new Vector2(horizontalInput, 0) * Time.deltaTime * moveSpeed);

        // Calling the previously created functions when keys are pressed to shoot gusts of wind
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnWindBottom();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnWindTop();
        }
    }
}
