using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DEALS WITH WHAT HAPPENS WHEN AN AIRSHIP HITS A PORT

public class PortTrigger : MonoBehaviour
{
    // Declaring a public static variable that can be accessed by any script
    [HideInInspector]
    public static int dockedAirships;

    // Creating a reference to the global enumerator denoting the airship or port type
    ShipOrPortType shipOrPortType;

    // Declaring variables
    Rigidbody2D airshipRigidbody;
    Collider2D airshipCollider;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Called when another collider hits the collider marked as a trigger on this game object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks to see if the collided object is tagged as an "Airship"
        if (other.CompareTag("Airship"))
        {
            // Checks to see if the Airship type that hit the port is equal to the port type
            if (other.gameObject.GetComponent<AirshipType>().shipOrPortType.Equals(this.gameObject.GetComponent<PortType>().shipOrPortType))
            {
                // Freeze the airship's position when it hits the port by accessing the constraints of the rigidbody component attached to the airship
                airshipRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
                airshipRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                // Disable the airship's collider so you can now shoot through it
                airshipCollider = other.gameObject.GetComponent<Collider2D>();
                airshipCollider.enabled = false;
                // Increase the public static variable by one that another script checks to see if the win condition is met
                dockedAirships += 1;
                // Play an audio clip assigned in the inspector on the port once
                audioSource.PlayOneShot(audioClip, 0.5f);
                Debug.Log("Successfully docked in port.");
                Debug.Log("Number of docked airships: " + dockedAirships);
            }
        }
    }
}
