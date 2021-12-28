using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT DEFINES THE BEHAVIOR OF THE GUSTS OF WIND THAT THE PLAYER CONTROLLER'S TOP CLOUD SHOOTS

public class TopWindBehavior : MonoBehaviour
{
    // Defining variables
    Rigidbody2D rb;
    public float windForce = 1f;
    public Animator anim;

    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        // Creating references to the wind's rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the wind collides with an airship...
        if (other.CompareTag("Airship"))
        {
            Debug.Log("Top wind hit airship.");
            // Grabbing the airship's rigidbody component
            GameObject airshipHit = other.gameObject;
            Rigidbody2D airshipHitRB = airshipHit.GetComponent<Rigidbody2D>();
            // Giving the airship's rigidbody a new velocity upward
            airshipHitRB.velocity = new Vector2(0f, -1f) * windForce;
            // Freezing the wind's position once it hits the airship
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            // Playing the wind's impact animation and audio clip
            anim.Play("TopWindImpact");
            audioSource.PlayOneShot(audioClip, 0.25f);
        }
    }

    // Destroying the wind game object after it finishes it's impact animation
    public void OnImpactAnimationFinish()
    {
        Destroy(this.gameObject);
    }
}
