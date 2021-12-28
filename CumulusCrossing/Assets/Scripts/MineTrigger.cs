using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS SCRIPT HANDLES WHAT HAPPENS WHEN AN AIRSHIP HITS A MINE

public class MineTrigger : MonoBehaviour
{
    // Declaring variables
    public GameObject LevelLoseUIText;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        // Turning the lose UI text off to start
        LevelLoseUIText.SetActive(false);
        // Creating a reference to the animator component on this game object
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Restarting the level when "R" is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reloads the active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Unpauses the game
            Time.timeScale = 1;
            // Resets the win condition
            PortTrigger.dockedAirships = 0;
        }
    }

    // Called when another collider hits the collider marked as a trigger on this game object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks to see if the collided object is tagged as an "Airship"
        if (other.CompareTag("Airship"))
        {
            // Creating a reference to the specific Airship that hit the mine
            GameObject airshipHit = other.gameObject;
            Destroy(airshipHit);
            // Calling the Play function of the animator to play a specifc Animation clip
            anim.Play("MineExplosion");
            // Playing the audio clip assigned in the inspector of the Mine game object
            audioSource.PlayOneShot(audioClip);
        }
    }

    // Creating a public method that I can call in an animation event when the animation finishes
    public void OnImpactAnimationFinish()
    {
        // Pause the game
        Time.timeScale = 0;
        // Enable the Lose UI text
        LevelLoseUIText.SetActive(true);
    }

}
