using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : MonoBehaviour
{
    private float speed;
    private float circleRadius;
    private float circleFrequency;
    private Vector3 startPosition;
    private Transform Player;
    private float timeOffset;

    void Start()
    {
        // Random downward speed
        speed = Random.Range(1.5f, 3f);
        // Circular movement parameters
        circleRadius = Random.Range(0.5f, 1.5f);
        circleFrequency = Random.Range(1f, 3f);

        startPosition = transform.position;

        // Find the player in the scene
        Player = GameObject.FindWithTag("Player").transform;

        // Randomize phase of circle motion
        timeOffset = Random.Range(0f, 2 * Mathf.PI);
    }

    void Update()
    {
        // Move downward toward player
        Vector3 direction = Vector3.down;

        if (Player != null)
        {
            // Adjust horizontal direction slightly toward player
            float horizontalDir = Mathf.Sign(Player.position.x - transform.position.x);
            direction.x = horizontalDir * 0.3f; 
        }

        // Circular motion offset
        float xOffset = Mathf.Cos(Time.time * circleFrequency + timeOffset) * circleRadius;
        float yOffset = Mathf.Sin(Time.time * circleFrequency + timeOffset) * circleRadius;

        Vector3 circularMovement = new Vector3(xOffset, yOffset, 0);

        // Apply movement
        transform.Translate((direction + circularMovement) * speed * Time.deltaTime);

        // Destroy if off-screen
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}
