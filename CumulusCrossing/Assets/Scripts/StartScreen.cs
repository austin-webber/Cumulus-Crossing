using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS SCRIPT HANDLES THE INPUT FUNCTIONALITY FOR THE START SCREEN

public class StartScreen : MonoBehaviour
{
    void Update()
    {
        // Adding input functionality to the game's Start Screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Retrieving the active scene index + 1, then loading that scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
