using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject bulletPrefab;
    public GameObject bigBulletPrefab; // NEW: Drag the large bullet prefab here in Inspector

    void Start()
    {
        playerSpeed = 6f;
    }

    void Update()
    {
        // Every frame
        Movement();
        Shooting();
    }

    void Shooting()
    {
        // Normal bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }

        // Big bullet
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bigBulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        // Read player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        // Wrap horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        // Clamp to bottom half of screen
        float minY = -verticalScreenLimit; // bottom
        float maxY = 0.5f; // midpoint
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }
}
