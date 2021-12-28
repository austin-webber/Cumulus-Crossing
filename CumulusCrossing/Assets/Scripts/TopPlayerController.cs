using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject otherPlayer;
    Rigidbody2D rb;
    Rigidbody2D otherRb;
    public bool topIsActive = false;
    BottomPlayerController bottomPC;

    public GameObject wind;
    public Transform windSpawnPoint;
    public float windSpeed = 1.0f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        otherRb = otherPlayer.GetComponent<Rigidbody2D>();
        bottomPC = otherPlayer.GetComponent<BottomPlayerController>();
    }

    private void SpawnWind()
    {
        GameObject newWind = Instantiate(wind) as GameObject;
        newWind.transform.position = windSpawnPoint.position;
        Rigidbody2D newWindRB = newWind.gameObject.GetComponent<Rigidbody2D>();
        newWindRB.velocity = new Vector2(0f, -1f) * windSpeed * 10;
    }

    void Update()
    {
        if (topIsActive == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector2(horizontalInput, 0) * Time.deltaTime * moveSpeed);

            if (Input.GetKeyDown(KeyCode.S))
            {
                topIsActive = false;
                bottomPC.bottomIsActive = true;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                otherRb.constraints = RigidbodyConstraints2D.None;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnWind();
            }
        }
    }
}