using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWinCondition : MonoBehaviour
{
    // Declaring variables
    public int winCondition;
    public GameObject winUIText;

    // THIS SCRIPT HANDLES WHAT HAPPENS WHEN YOU DOCK ALL THE AIRSHIPS (BEAT THE LEVEL)

    void Start()
    {
        // Disabling the win UI text to start
        winUIText.SetActive(false);
    }

    void Update()
    {
        // Quit the game if "Escape" is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // dockedAirships is a public static variable that can be accessed by any script. It is increased by one when an airship hits a port.
        // You win if the amount of docked airships equals the win condition set in the inspector.
        if (PortTrigger.dockedAirships == winCondition)
        {
            // Pause time
            Time.timeScale = 0;
            // Enable the win UI text
            winUIText.SetActive(true);

            // Go to the next level if the player has won the level and presses "Return"
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // Load the next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                // Unpause the game
                Time.timeScale = 1;
                // Reset the win condition for the next level
                PortTrigger.dockedAirships = 0;
            }
        }
    }
}
