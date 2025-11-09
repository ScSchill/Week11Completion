using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float speed;
    private Vector3 moveDirection;

    public Transform player;

    void Start()
    {
        // Set random speed
        speed = Random.Range(2f, 5f);

        // Set initial diagonal direction toward player at spawn
        if (player != null)
        {
            Vector3 target = player.position;
            moveDirection = (target - transform.position).normalized;

            // Ensure it keeps a diagonal trajectory even if player is directly above/below
            if (Mathf.Abs(moveDirection.x) < 0.3f)
                moveDirection.x = moveDirection.x < 0 ? -0.3f : 0.3f;
            if (Mathf.Abs(moveDirection.y) < 0.3f)
                moveDirection.y = moveDirection.y < 0 ? -0.3f : 0.3f;
        }
        else
        {
            // Default diagonal if player reference missing
            moveDirection = new Vector3(0.5f, -1f, 0).normalized;
        }
    }

    void Update()
    {
        // Move in initial diagonal direction
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Destroy if off-screen
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
}
