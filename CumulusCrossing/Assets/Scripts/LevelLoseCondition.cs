using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS SCRIPT HANDLES WHAT HAPPENS WHEN YOU LOSE A LEVEL AND THE PROCEEDING INPUT FUNCTIONALITY TO RESET THE LEVEL

public class LevelLoseCondition : MonoBehaviour
{
    // Public variables I can assign canvas objects and components to in the inspector
    public GameObject levelLoseUI;
    public Animator anim;

    private void Start()
    {
        // Turn off the UI text to start
        levelLoseUI.SetActive(false);
        // Creating a reference to the Animator component on this game object
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Restarting the level by reloading the current scene when "R" is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Unpausing the game
            Time.timeScale = 1;
            // Resetting the win condition
            PortTrigger.dockedAirships = 0;
        }
    }

    // OnBecameInvisible() is called when the renderer is no longer visible by a camera, a good way to check if the object has left the screen
    private void OnBecameInvisible()
    {
        // This seems strange to play an explosion animation when we can't even see the ship anymore, but if the ship hits a mine, it becomes invisible before the explosion animation plays, so this covers our bases
        anim.Play("ShipExplosion");
    }

    // Creating a public method that I can call in an animation event when the animation finishes
    public void OnExplosionAnimationFinish()
    {
        levelLoseUI.SetActive(true);
        Time.timeScale = 0;
   
    }
}
