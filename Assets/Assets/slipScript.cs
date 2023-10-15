using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipScript : MonoBehaviour
{
    public float slidingForce = 5f; // Adjust this value to control the sliding force.

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            // Calculate the direction of the sliding force based on the player's current velocity.
            Vector2 slideDirection = playerRb.velocity.normalized;

            // Apply the sliding force in the direction of the player's velocity.
            playerRb.AddForce(slideDirection * slidingForce, ForceMode2D.Force);
        }
    }
}