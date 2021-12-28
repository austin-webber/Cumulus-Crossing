using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SCRIPT MAKES SURE THE PLAYER CAN'T LEAVE THE SCREEN
public class Boundaries : MonoBehaviour
{
    private void Update()
    {
        // Creates a new Vector3 relevant to the player's position in the Viewport instead of the player's position in the world
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        // Then clamps the player's position 0 and 1 on the x and y axis.
        // 0 being the far left or the bottom of the viewport, and 1 being the far right and top of the viewport
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        // converting the game object's position back into world space from viewport space
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
